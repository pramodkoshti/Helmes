import { EventListenerFocusTrapInertStrategy } from '@angular/cdk/a11y';
import {SelectionModel} from '@angular/cdk/collections';
import {FlatTreeControl} from '@angular/cdk/tree';
import {Component, Injectable} from '@angular/core';
import {MatTreeFlatDataSource, MatTreeFlattener} from '@angular/material/tree';
import { TreeNode } from '@circlon/angular-tree-component';
import {BehaviorSubject} from 'rxjs';
import { ManufacturingService } from './Services/ManufacturingService';



export class UserDetails {
  Username: string = "";
  SectorsIds: string = "";
  IsAgreeToTerms: boolean = false;
  SessionId: string = "";
  UserSectors: any = [];
  }


  class Guid {
    static newGuid() {
      return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
        var r = Math.random() * 16 | 0,
          v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
      });
    }
  }

/**
 * Node for to-do item
 */
export class TodoItemNode {
  children!: TodoItemNode[];
  label!: string;
  id!:number;
  isChecked!:boolean;
  isPlanType!: boolean;
  claimId!: number;
}

/** Flat to-do item node with expandable and level information */
export class TodoItemFlatNode {
  label!: string;
  level!: number;
  expandable!: boolean;
   id!:number;
  isChecked!:boolean;
   isPlanType!: boolean;
   claimId!: number;
}

/**
 * The Json object for to-do list data.
 */
export const TREE_DATA : any = [];
 
 
 
@Injectable()
export class ChecklistDatabase {
  dataChange = new BehaviorSubject<TodoItemNode[]>([]);

  get data(): TodoItemNode[] { return this.dataChange.value; }

  constructor() {
    this.initialize(TREE_DATA);
  }

  initialize(TREE_DATA2:any) {
    // Build the tree nodes from Json object. The result is a list of `TodoItemNode` with nested
    //     file node as children.
    const data = this.buildFileTree(TREE_DATA2, 0);
     
    // Notify the change.
    this.dataChange.next(data);
  }

  /**
   * Build the file structure tree. The `value` is the Json object, or a sub-tree of a Json object.
   * The return value is the list of `TodoItemNode`.
   */
  buildFileTree(obj: {[key: string]: any}, level: number): TodoItemNode[] {
    return Object.keys(obj).reduce<TodoItemNode[]>((accumulator, key) => {
      const item = obj[key];
      const node = new TodoItemNode();
      node.label = obj[key].name;
      node.id = obj[key].id;
      node.isChecked=  obj[key].isChecked;
 node.claimId=  obj[key].claimId;
 node.isPlanType=  obj[key].isPlanType;

      if (item != null) {
        if (typeof item === 'object'  && item.children!= undefined) {        
          node.children = this.buildFileTree(item.children, level + 1);
        } else {
          node.label = item.name;
        }
      }
      return accumulator.concat(node);
    }, []);
  }

  /** Add an item to to-do list */
  insertItem(parent: TodoItemNode, name: string) {
    if (parent.children) {
      parent.children.push({label: name} as TodoItemNode);
      this.dataChange.next(this.data);
    }
  }

  updateItem(node: TodoItemNode, name: string) {
    node.label = name;
    this.dataChange.next(this.data);
  }
}

/**
 * @title Tree with checkboxes
 */
@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.css'],
  providers: [ChecklistDatabase]
})
export class TreeChecklistExample {
  /** Map from flat node to nested node. This helps us finding the nested node to be modified */
  flatNodeMap = new Map<TodoItemFlatNode, TodoItemNode>();

  /** Map from nested node to flattened node. This helps us to keep the same object for selection */
  nestedNodeMap = new Map<TodoItemNode, TodoItemFlatNode>();

  /** A selected parent node to be inserted */
  selectedParent: TodoItemFlatNode | null = null;

  /** The new item's name */
  newItemName = '';

  errorMsg="";

  treeControl: FlatTreeControl<TodoItemFlatNode>;

  treeFlattener: MatTreeFlattener<TodoItemNode, TodoItemFlatNode>;

  dataSource: MatTreeFlatDataSource<TodoItemNode, TodoItemFlatNode>;

  /** The selection for checklist */
  checklistSelection = new SelectionModel<TodoItemFlatNode>(true /* multiple */);
  sectors: any;
  username :string =""
  termsConditions : boolean = false;

  constructor(private database: ChecklistDatabase, private service:ManufacturingService) {
    this.treeFlattener = new MatTreeFlattener(this.transformer, this.getLevel,
      this.isExpandable, this.getChildren);
    this.treeControl = new FlatTreeControl<TodoItemFlatNode>(this.getLevel, this.isExpandable);
    this.dataSource = new MatTreeFlatDataSource(this.treeControl, this.treeFlattener);

    database.dataChange.subscribe(data => {
      this.dataSource.data = data;
    });
  }


  getLevel = (node: TodoItemFlatNode) => node.level;

  isExpandable = (node: TodoItemFlatNode) => node.expandable;

  getChildren = (node: TodoItemNode): TodoItemNode[] => node.children;

  hasChild = (_: number, _nodeData: TodoItemFlatNode) => _nodeData.expandable;

  hasNoContent = (_: number, _nodeData: TodoItemFlatNode) => _nodeData.label === '';

  /**
   * Transformer to convert nested node to flat node. Record the nodes in maps for later use.
   */
  transformer = (node: TodoItemNode, level: number) => {
    const existingNode = this.nestedNodeMap.get(node);
    const flatNode = existingNode && existingNode.label === node.label
        ? existingNode
        : new TodoItemFlatNode();
    flatNode.label = node.label;
    flatNode.level = level;
    flatNode.id=node.id;
     flatNode.isChecked = node.isChecked;
     flatNode.claimId = node.claimId;
     flatNode.isPlanType = node.isPlanType;
    flatNode.expandable = !!node.children;
    this.flatNodeMap.set(flatNode, node);
    this.nestedNodeMap.set(node, flatNode);
    return flatNode;
  }

  /** Whether all the descendants of the node are selected. */
  descendantsAllSelected(node: TodoItemFlatNode): boolean {
    const descendants = this.treeControl.getDescendants(node);
    const descAllSelected = descendants.every(child =>
     this.checklistSelection.isSelected(child))
    return descAllSelected;
  }

  /** Whether part of the descendants are selected */
  descendantsPartiallySelected(node: TodoItemFlatNode): boolean {
    const descendants = this.treeControl.getDescendants(node);
    const result = descendants.some(child => this.checklistSelection.isSelected(child));
    return result && !this.descendantsAllSelected(node);
  }

  /** Toggle the to-do item selection. Select/deselect all the descendants node */
  todoItemSelectionToggle(node: TodoItemFlatNode): void {
  
    this.checklistSelection.toggle(node);
    const descendants = this.treeControl.getDescendants(node);
    this.checklistSelection.isSelected(node)
      ? this.checklistSelection.select(...descendants)
      : this.checklistSelection.deselect(...descendants);

    // Force update for the parent
    descendants.every(child =>
      this.checklistSelection.isSelected(child)
    );
    this.checkAllParentsSelection(node);
  }

  /** Toggle a leaf to-do item selection. Check all the parents to see if they changed */
  todoLeafItemSelectionToggle(node: TodoItemFlatNode): void {
    this.checklistSelection.toggle(node);
    node.isChecked ?  node.isChecked=false:node.isChecked=true; 
    this.checkAllParentsSelection(node);
  }

  /* Checks all the parents when a leaf node is selected/unselected */
  checkAllParentsSelection(node: TodoItemFlatNode): void {
    let parent: TodoItemFlatNode | null = this.getParentNode(node);

    while (parent) {
      this.checkRootNodeSelection(parent);
      parent = this.getParentNode(parent);
    }

  }

  /** Check root node checked state and change it accordingly */
  checkRootNodeSelection(node: TodoItemFlatNode): void {
    const nodeSelected = this.checklistSelection.isSelected(node);
    const descendants = this.treeControl.getDescendants(node);
    const descAllSelected = descendants.every(child =>
      this.checklistSelection.isSelected(child)
    );
    if (nodeSelected && !descAllSelected) {
      this.checklistSelection.deselect(node);
    } else if (!nodeSelected && descAllSelected) {
      this.checklistSelection.select(node);
    }
  }

  /* Get the parent node of a node */
  getParentNode(node: TodoItemFlatNode): TodoItemFlatNode | null {
    const currentLevel = this.getLevel(node);

    if (currentLevel < 1) {
      return null;
    }

    const startIndex = this.treeControl.dataNodes.indexOf(node) - 1;

    for (let i = startIndex; i >= 0; i--) {
      const currentNode = this.treeControl.dataNodes[i];

      if (this.getLevel(currentNode) < currentLevel) {
        return currentNode;
      }
    }
    return null;
  }

  /** Select the category so we can insert the new item. */
  addNewItem(node: TodoItemFlatNode) {
    const parentNode = this.flatNodeMap.get(node);
    this.database.insertItem(parentNode!, '');
    this.treeControl.expand(node);
  }

  /** Save the node to database */
  saveNode(node: TodoItemFlatNode, itemValue: string) {
    alert('Hi')
    const nestedNode = this.flatNodeMap.get(node);
    this.database.updateItem(nestedNode!, itemValue);
  }

  buildTree(id:number | null, parentId:number | null, node:any):any {

    let object:any
    if(parentId) {
        let filter = this.sectors.filter((x: { pid: number; }) => x.pid == parentId)
        if(filter.length > 0){
          node.children = filter
        }
        else{
          node.children = null;
        }
    }
  
  if(id == null){
    id = parentId;
  }
  if(id != null){
    let s = this.sectors.filter((x: { pid: number; }) => x.pid == id)
    if(s.length > 0){
      object = {     
        name: this.sectors.find((x: { id: number; }) => x.id == id).name,
        isChecked :false,
        isPlanType  : false,
        claimId : id,
        children: this.sectors.filter((x: { pid: number; }) => x.pid == id)
      }
    }
    else{
      object = {     
        name: this.sectors.find((x: { id: number; }) => x.id == id).name,
        isChecked :false,
        isPlanType  : false,
        claimId : id,
        children: null
    }
    }
  }
  
  var iterator = object != null ? object : node;
    if(iterator.children != null){
      iterator.children.forEach((children:any) => {
       
        this.buildTree(null, children.id, children)
    })
    }
      return object
  }
  
  ngonviewInit():void{
    alert('Hi')
  }

  ngOnInit(): void {
    var TEST_DATA : any = [];
    let sessionId = localStorage.getItem("currentSession");
    if(sessionId !== null){
      this.service.getUserDetailsBySessionId(sessionId)
      .subscribe((response:any) => {
        this.username = response.username;
        this.termsConditions = response.isAgreeToTerms;
        this.sectors = response.userSectors;
        this.sectors.forEach((row:any) => {
          if(row.pid == null){
            var object = this.buildTree(row.id , row.pid, null)
            
            TEST_DATA.push(object);     
          }                  
        })
        this.database.initialize(TEST_DATA)
      }); 
    }
    else{
      this.service.getSectors()
      .subscribe((response:any) => {
        this.sectors = response;
        this.sectors.forEach((row:any) => {
          if(row.pid == null){
            var object = this.buildTree(row.id , row.pid, null)
            
            TEST_DATA.push(object);     
          }                  
        })
        this.database.initialize(TEST_DATA)
      }); 
    }
    }          

levels : any  = []
    SaveInfo(){
      //Reactive form validations can be used
      if (this.username == ""){
        this.errorMsg="Please enter your name";
        return
      }
      else if(this.treeControl.dataNodes.filter(x => x.isChecked == true).length == 0){
        this.errorMsg="Please select at least one sector";
        return
      }
      else if(!this.termsConditions){
        this.errorMsg="Please agree to terms";
        return      
      }
      this.errorMsg = ""
      var userDetails = new UserDetails();
      userDetails.IsAgreeToTerms =this.termsConditions;
      if(localStorage.getItem('currentSession') == null){
        userDetails.SessionId = Guid.newGuid();
      }
      else{
        userDetails.SessionId = JSON.parse(JSON.stringify(localStorage.getItem('currentSession')))
      }
      userDetails.Username = this.username;
      userDetails.SectorsIds = this.treeControl.dataNodes.filter(x => x.isChecked == true).map(x => x.id).join(',');
      localStorage.setItem('currentSession', userDetails.SessionId);
      this.service.saveData(userDetails).subscribe(res => { 
        let result: any = res.body;
        this.errorMsg="Details saved successfully";    
      },
      err => {
        this.errorMsg=err;    
      }
     );
    }
    
}
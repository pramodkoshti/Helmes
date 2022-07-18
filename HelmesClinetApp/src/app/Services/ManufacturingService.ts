import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
  
@Injectable({
  providedIn: 'root'
})
export class ManufacturingService {
  private url = 'http://localhost:44299/manufacturing';
  


  constructor(    
    private httpClient: HttpClient
    ) { 
    }
  
  

  public sector_list : any = []

  getSectors(){
    return this.httpClient.get(this.url + "/GetSectors");
  }

  getUserDetailsBySessionId(guid: any){
    return this.httpClient.get(this.url +  "/UserDetails?sessionId=" + guid);
  }


  // saveData(userDetails : any){
  //   return this.httpClient.post(this.url, JSON.stringify( userDetails));
  // }  

  saveData(userDetails: any): Observable<HttpResponse<any>> {
    let httpHeaders = new HttpHeaders({
       'Content-Type' : 'application/json'
    });    
    return this.httpClient.post<any>(this.url, userDetails,
      {
        headers: httpHeaders,
        observe: 'response'
      }
    );
  } 
}

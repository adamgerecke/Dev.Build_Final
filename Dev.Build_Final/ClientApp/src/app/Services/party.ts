import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { party } from "../interfaces/Iparty";

@Injectable({
  providedIn: 'root'
})
export class partyService {
  constructor(private http: HttpClient) { }

  userID = 'The_User';


  partyUrl = '/api/party';



  getAllParty() {
    return this.http.get(`${this.partyUrl}`);
  }

  toggleDone(item:party) {
    const headers = { 'content-type': 'application/json' };
    const body = JSON.stringify(item);
    var newURL = this.partyUrl + '/check'
    return this.http.post<party>(newURL, body, { 'headers': headers }).subscribe((data) => console.log(data));
  
  }

  

}

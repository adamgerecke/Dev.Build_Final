import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

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
}

import { Component } from '@angular/core';
import { partyService } from '../Services/party';
import { party } from '../interfaces/Iparty';


@Component({
    selector: 'app-party',
    templateUrl: './party.component.html',
    styleUrls: ['./party.component.css']
})
/** party component*/
export class PartyComponent {
    /** party ctor */
  constructor(private party: partyService) { }

  partyList: party
  item: party

  ngOnInit(): void {

    this.party.getAllParty().subscribe(
      (data: party) =>
        this.partyList = data
    );
  }

  checkbox(item:party) {
    this.party.toggleDone(item);
    this.ngOnInit();
  }

}

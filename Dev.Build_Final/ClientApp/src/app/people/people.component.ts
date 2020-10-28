import { Component } from '@angular/core';
import { peopleService } from '../Services/people';
import { people } from '../interfaces/Ipeople';

@Component({
    selector: 'app-people',
    templateUrl: './people.component.html',
    styleUrls: ['./people.component.css']
})
/** people component*/
export class PeopleComponent {
  /** people ctor */
  constructor(private people: peopleService) { }

  peopleList: people
  person: people

  newPerson: people = {
    id: null,
    firstname:  '',
    lastname:  ''
  }

  ngOnInit(): void {
    this.people.getPeopleList().subscribe(
      (data: people) =>
        this.peopleList = data
    );
  }

  addPerson() {
    this.people.AddPerson(this.newPerson);
    this.newPerson.firstname = '';
    this.newPerson.lastname = '';
  }

  removePerson(person: people) {
    this.people.removePerson(person);
  }







}

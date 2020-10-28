import { Component } from '@angular/core';
import { giftService } from '../Services/gifts';
import { gift } from '../interfaces/Igifts';

@Component({
    selector: 'app-gifts',
    templateUrl: './gifts.component.html',
    styleUrls: ['./gifts.component.css']
})
/** gifts component*/
export class GiftsComponent {
    /** gifts ctor */
  constructor(private gifts: giftService) { }

  giftList: gift
  item: gift

  newGiftItem: gift = {
    description: '',
    done: false,
    userid: null
  }

  ngOnInit(): void {
    this.gifts.getGiftsFromUser().subscribe(
      (data: gift) =>
        this.giftList = data
    );
  }

  checkbox(item: gift) {
    this.gifts.toggleDone(item);
    this.ngOnInit();
  }

  newItem() {
    this.gifts.newGiftItem(this.newGiftItem);
    this.newGiftItem.description = '';
  }

  removeGift(item: gift) {
    this.gifts.removeGiftItem(item);
  }


}

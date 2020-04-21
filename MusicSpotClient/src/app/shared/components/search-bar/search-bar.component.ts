import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.scss']
})
export class SearchBarComponent implements OnInit {

  @Output() onSearch: EventEmitter<string> = new EventEmitter<string>();

  customInput : Subject<string> = new Subject();

  constructor() { }

  ngOnInit() {
    this.customInput.pipe(
      debounceTime(1000)).subscribe(value =>{
        this.onSearch.emit(value);
   });
  }

  searchChanged(text: any){
    this.customInput.next(text);
  }

}

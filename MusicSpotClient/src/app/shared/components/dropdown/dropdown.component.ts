import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-dropdown',
  templateUrl: './dropdown.component.html',
  styleUrls: ['./dropdown.component.scss']
})
export class DropdownComponent implements OnInit {

  @Input() items : DropdownItem[] = [];
  @Input() label: string = "";

  @Output() onChange: EventEmitter<string> = new EventEmitter<string>();

  constructor() { }

  ngOnInit() {
  }


  public onChangeOption(event: any): void{
    this.onChange.emit(event.value);
  }

}


export class DropdownItem{
  public id: string;
  public name: string;
}

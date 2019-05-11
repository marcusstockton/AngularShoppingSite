import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { IItem, Item } from '../../models/Item';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-item-form',
  templateUrl: './item-form.component.html',
  styleUrls: ['./item-form.component.css']
})

export class ItemFormComponent implements OnInit {

  itemId: string;
  item: IItem;
  itemForm = this.fb.group({
    id: [''],
    title: [''],
    name: [''],
    description: [''],
    price: [''],
    createdDate: [''],
    updatedDate: [''],
    createdBy: [''],
    updatedBy: ['']
  });

  @Input() Item: IItem;

  @Output() editEvent: EventEmitter<IItem> = new EventEmitter<IItem>();

  @Output() createEvent: EventEmitter<IItem> = new EventEmitter<IItem>();

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    if (this.Item) {
      this.itemForm.patchValue({
        id: this.Item.id,
        title: this.Item.title,
        name: this.Item.name,
        description: this.Item.description,
        price: this.Item.price,
        createdDate: this.Item.createdDate,
        updatedDate: this.Item.updatedDate,
        createdBy: this.Item.createdBy,
        updatedBy: this.Item.updatedBy
    });
    }
  }

  onSubmit() {
    if (this.itemForm.get('id').value) {
      // Editing:
      this.editEvent.emit(this.itemForm.value);
    } else {
      // Creating:
      this.createEvent.emit(this.itemForm.value);
    }
  }
}

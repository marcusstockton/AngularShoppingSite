import { Component, OnInit, Input, Output, EventEmitter, ChangeDetectorRef } from '@angular/core';
import { IItem, Item } from '../../models/Item';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-item-form',
  templateUrl: './item-form.component.html',
  styleUrls: ['./item-form.component.css']
})

export class ItemFormComponent implements OnInit {

  itemId: string;
  item: IItem;
  itemForm: FormGroup;
  images: Array<File>;

  @Input() Item: IItem;

  @Output() editEvent: EventEmitter<IItem> = new EventEmitter<IItem>();

  @Output() createEvent: EventEmitter<IItem> = new EventEmitter<IItem>();

  constructor(private fb: FormBuilder, private cd: ChangeDetectorRef) {
    this.itemForm = this.createFormComponent();
    this.images = new Array<File>();
  }

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
        updatedBy: this.Item.updatedBy,
        createdById: this.Item.createdById,
        updatedById: this.Item.updatedById,
        images: null,
    });
    }
  }

  createFormComponent() {
    return this.fb.group({
      id: [''],
      title: [''],
      name: [''],
      description: [''],
      price: [''],
      createdDate: [''],
      updatedDate: [''],
      createdBy: [''],
      updatedBy: [''],
      updatedById: [''],
      createdById: [''],
      images: ['']
    });
  }

  onSubmit() {
    // Not passing the image in this.itemForm.value...
    if (this.itemForm.get('id').value) {
      this.itemForm.controls.images.setValue(this.images);
      // Editing:
      this.editEvent.emit(this.itemForm.value);
    } else {
      // Creating:
      this.createEvent.emit(this.itemForm.value);
    }
  }

  onFileChange(images: Array<File>) {
    for(let image of images){
      this.images.push(image);
    }
  }
}

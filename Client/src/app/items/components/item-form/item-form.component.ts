import { Component, OnInit, Input, Output, EventEmitter, ChangeDetectorRef } from '@angular/core';
import { IItem, Item, IItemCreate } from '../../models/Item';
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

  @Output() createEvent: EventEmitter<IItemCreate> = new EventEmitter<IItemCreate>();

  constructor(private fb: FormBuilder, private cd: ChangeDetectorRef) {
    this.itemForm = this.createFormComponent();
    this.images = new Array<File>();
  }

  ngOnInit(): void {
    if (this.Item) {
      this.images = this.Item.images;
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
      images: [''],
      createdBy: [''],
      createdDate: [''],
    });
  }

  onSubmit() {
    this.itemForm.controls.images.setValue(this.images);
    // Not passing the image in this.itemForm.value...
    if (this.itemForm.get('id').value) {
      // Editing:
      this.editEvent.emit(this.itemForm.value);
    } else {
      // Creating:
      this.createEvent.emit(this.itemForm.value);
    }
  }

  onFileChange(images: Array<File>) {
    for (let image of images) {
      this.images.push(image);
    }
  }
}

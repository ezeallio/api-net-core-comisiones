import { Component, OnInit, Input } from '@angular/core';
import { PackageItemDTO } from '../PackageItemDTO';
import { ItemType } from '../ItemTypeEnum';

@Component({
  selector: 'app-detail-package',
  templateUrl: './detail-package.component.html',
  styleUrls: ['./detail-package.component.css']
})
export class DetailPackageComponent implements OnInit {

  @Input() packageItemDTO: PackageItemDTO;

  keys = Object.keys(ItemType).filter(k => typeof ItemType[k as any] === "number");
  
  close(): void{
    this.packageItemDTO = null;
  }

  constructor() { }
  
  ngOnInit() {
  }

}

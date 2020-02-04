import { Component, OnInit } from '@angular/core';
import { PackageDTO } from '../PackageDTO';
import { TravelDTO } from '../TravelDTO';
import { PackageItemDTO } from '../PackageItemDTO';
import { PackageService } from '../package.service';
import { ClientType } from '../ClientTypeEnum';

@Component({
  selector: 'app-calculate-commission',
  templateUrl: './calculate-commission.component.html',
  styleUrls: ['./calculate-commission.component.css']
})
export class CalculateCommissionComponent implements OnInit {

  packages: PackageDTO[] = [];
  packageDetails: PackageItemDTO;
  idsAdded: number[] = [];
  packagesAdded: PackageDTO[] = [];
  commission: number;
  error: string;
  keys = Object.keys(ClientType).filter(k => typeof ClientType[k as any] === "number");
  values = this.keys.map(k => ClientType[k as any]);

  viewDetails(id:number) : void{
    this.packageService.getPackage(id).subscribe(pack => this.packageDetails = pack);
  }

  search(description: string): void{
    this.packageService.getPackages(description)
    .subscribe(packages => packages.length > 0 ? this.packages = packages : this.packages = null);
  }

  addPackage(packAdded: PackageDTO): void{
    this.idsAdded.push(packAdded.packageId);
    this.packagesAdded.push(packAdded);
  }

  removePackage(packRemoved: PackageDTO): void{
    this.idsAdded = this.idsAdded.filter(x => x !== packRemoved.packageId);
    this.packagesAdded = this.packagesAdded.filter(x => x !== packRemoved);
  }

  calculate(cType: number, totPassengers: number, totNights: number): void{
    this.error = '';
    this.commission = null;
    
    if(ClientType[cType] != null && this.idsAdded.length > 0
      && totPassengers > 0 && totPassengers <= 10 && totNights > 0 && totNights <= 60){
        
      this.packages = [];

      const travel: TravelDTO = {
        clientType : cType,
        passengers : totPassengers,
        nights : totNights,
        idsPackages : this.idsAdded
      };
  
      this.packageService.postTravel(travel).subscribe(commission => this.commission = commission);
    }
    else
      this.error = "Error! data isn't complete or invalid";
  }

  constructor(private packageService: PackageService) { }

  ngOnInit() {
  }

}

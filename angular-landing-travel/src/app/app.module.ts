import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CalculateCommissionComponent } from './calculate-commission/calculate-commission.component';
import { DetailPackageComponent } from './detail-package/detail-package.component';

@NgModule({
  declarations: [
    AppComponent,
    CalculateCommissionComponent,
    DetailPackageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

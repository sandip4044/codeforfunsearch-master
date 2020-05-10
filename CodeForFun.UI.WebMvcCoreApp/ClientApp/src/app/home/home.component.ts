import { Component, OnInit, Input, SecurityContext } from '@angular/core';
import { FormControl } from '@angular/forms';
import { SearchMasterServiceService } from '../search-master-service.service';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { debounceTime, tap, switchMap, finalize } from 'rxjs/operators';
import { ViewChild } from '@angular/core';
import { MatAutocompleteTrigger } from '@angular/material';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [SearchMasterServiceService]
})

export class HomeComponent {

  errorMsg: string;

  searchTerm: FormControl = new FormControl();
  drpDownData = <any>[];
  mySearchData = <any>[];

  constructor(private service: SearchMasterServiceService, private sanitizer: DomSanitizer) { }

  ngOnInit() {
    this.fillDropDownData();
    this.getAllSearchData(event);
  }

  // to be fill autofill dropdown
  fillDropDownData() {
    this.searchTerm.valueChanges.subscribe(
      term => {
        this.service.search(term).subscribe(
          data => {
            this.drpDownData = data == "" ? [] : data as any[];
          })
      })
  }

  // to be fill autofill dropdown
  getAllSearchData(event) {
    //this.autoComplete.closePanel();
    this.searchTerm.valueChanges.subscribe(
      term => {
        this.service.searchAll(term).subscribe(
          data => {
            this.mySearchData = data == "" ? [] : data as any[];
          })
      })
  }

}

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { debounceTime } from 'rxjs/internal/operators/debounceTime';

@Injectable({
  providedIn: 'root'
})
export class SearchMasterServiceService {

  AppURL: string;
  constructor(private httpService: HttpClient) {
    //this.AppURL = "http://localhost/CodeForFun.UI.WebMvcCoreApp";
    this.AppURL = "http://localhost:53161/";
  }

  search(term) {
    var listOfBooks = this.httpService.get(this.AppURL + 'SearchMaster/getautofilldata?searchText=' + term)
      .pipe(
        debounceTime(500),
        map(
          (data: any) => {
            if (data != null) {
              return (
                data.length != 0 ? data as any[] : []
                //data.length != 0 ? data as any[] : [{ "searchPath": "#", "searchDescription" : "No Records Found" } as any]
              );
            }
            else {
              return "";
            }

          }
        ));

    return listOfBooks;
  }

  searchAll(term) {
    var listOfBooks = this.httpService.get(this.AppURL + 'SearchMaster/searchData?searchText=' + term)
      .pipe(
        debounceTime(500),
        map(
          (data: any) => {
            if (data != null) {
              return (
                data.length != 0 ? data as any[] : []
                //data.length != 0 ? data as any[] : [{ "searchPath": "#", "searchDescription": "No Records Found" } as any]
              );
            }
            else {
              return "";
            }

          }
        ));

    return listOfBooks;
  }
}

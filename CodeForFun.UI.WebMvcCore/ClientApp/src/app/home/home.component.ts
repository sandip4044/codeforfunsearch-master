import { Component, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
//import { MatAutocompleteModule } from '@angular/material/autocomplete';
import 'rxjs/add/operator/do';
import 'rxjs/add';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public declarativeFormCaptchaValue: string;
  public reactiveForm;
url:string='';
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.reactiveForm = new FormGroup({
      recaptchaReactive: new FormControl(null, Validators.required)
    });
    this.url=baseUrl;
  }
  myControl = ['One', 'Two', 'Three', 'Four'];

  @Inject('BASE_URL') baseUrl: string;
  submit(captchaResponse: string): void {
    console.log(captchaResponse);
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let body = JSON.stringify({ recaptchaResponse: captchaResponse });
    // this.http.post('/GoogleReCaptcha/ValidGoogleReCaptcha', body)
    //   .subscribe(res => { console.log(res) }, //For Success Response
    //     err => { console.error(err) } //For Error Response
    //   );
    // const string1='asdf';
    // this.http.get(this.url + 'weatherforecast/Get?tiger='+string1).subscribe(result => {
    //   debugger
    // }, error => console.log(error));
debugger
   this.http.get('https://localhost:44385/GoogleReCaptcha/ValidGoogleReCaptcha?recaptchaResponse='+captchaResponse).subscribe(result => {
     console.log('result'+result);
    }, error => console.log(error));
  }
}

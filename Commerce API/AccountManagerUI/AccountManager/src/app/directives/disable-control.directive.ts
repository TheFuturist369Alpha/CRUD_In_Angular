import { Directive, Input } from '@angular/core';
import { FormControl, NgControl } from '@angular/forms';

@Directive({
  selector: '[disableControl]'
})
export class DisableControlDirective {

  public constructor(private control: NgControl) {


  }
  @Input()

  set disableControl(condition: boolean) {
    var control = this.control.control as FormControl;
    if (control != null) {
      if (condition) {
        control.disable();
      }
      else {
        control.enable();
      }
    }
  }

}

import { Component } from '@angular/core';

@Component({
    selector: 'app-footer',
    templateUrl: './footer.component.html',
    styleUrls: ['./footer.component.css']
})
export class FooterComponent {
    /** The current year which is shown in the footer as copyright */
    public year = new Date().getFullYear();
}

import { Component } from "@angular/core";
import { Subject } from "rxjs/Subject";

@Component({
    templateUrl: "./home-admin-page.component.html",
    styleUrls: ["./home-admin-page.component.css"],
    selector: "ce-home-admin-page"
})
export class HomeAdminPageComponent { 

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }
}

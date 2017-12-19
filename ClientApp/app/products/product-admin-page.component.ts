import { Component } from "@angular/core";
import { Subject } from "rxjs/Subject";

@Component({
    templateUrl: "./product-admin-page.component.html",
    styleUrls: ["./product-admin-page.component.css"],
    selector: "ce-product-admin-page"
})
export class ProductAdminPageComponent { 

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }
}

import { Component, OnInit } from '@angular/core';
import { StockService } from '../shared/stock.service';
import { AbstractControl, FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Stock } from '../shared/stock.model';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-stock-editor',
    templateUrl: './stock-editor.component.html'
})
export class StockEditorComponent implements OnInit {
    /** The form to create or update a Stock. */
    public stockForm: FormGroup;

    /**
     * Creates a new instance of StockEditor.
     *
     * @param stockService The via dependency injection loaded service for stock actions.
     * @param toastrService The via dependency injection loaded service for showing toasts.
     * @param router The via dependency injection loaded router for navigation actions.
     * @param formBuilder The via dependency injection loaded formBuilder for setting up the editor.
     */
    public constructor(public stockService: StockService,
                       private toastrService: ToastrService,
                       private router: Router,
                       private formBuilder: FormBuilder) {
        this.stockForm = this.formBuilder.group(new Stock());
    }

    /**
     * Patches the values of the StockEditor with values of the record if it exists.
     */
    public ngOnInit(): void {
        if (this.stockService.formData.id !== 0) {
            this.stockForm.patchValue(this.stockService.formData);
        }
    }

    /**
     * Submits the data of the stockForm and creates the record if its id is 0.
     * If the id is not 0 an update action will be triggered.
     */
    public onSubmit(): void {
        if (!this.stockForm.valid) {
            return;
        }

        // eslint-disable-next-line @typescript-eslint/no-unsafe-assignment
        this.stockService.formData = this.stockForm.value;

        if (this.stockService.formData.id === 0) {
            this.insertRecord();
        } else {
            this.updateRecord();
        }
    }

    /**
     * Returns the name property of the StockForm.
     */
    public get name(): AbstractControl | null {
        return this.stockForm.get('name');
    }

    /**
     * Returns the name amount of the StockForm.
     */
    public get amount(): AbstractControl | null {
        return this.stockForm.get('amount');
    }

    /**
     * Returns the acquisitionPricePerUnit property of the StockForm.
     */
    public get acquisitionPricePerUnit(): AbstractControl | null {
        return this.stockForm.get('acquisitionPricePerUnit');
    }

    private resetForm(): void {
        this.stockForm.reset();
        this.stockService.formData = new Stock();
    }

    private insertRecord(): void {
        this.stockService.postStock().subscribe(
            () => {
                this.toastrService.success($localize`Stock is created.`);
                this.resetForm();
                void this.router.navigate(['stocks']);
            },
            error => {
                this.toastrService.error($localize`Creating stock failed.`);
                console.error(error);
            }
        );
    }

    private updateRecord(): void {
        this.stockService.updateStock().subscribe(
            () => {
                this.toastrService.success($localize`Stock is updated.`);
                this.resetForm();
                void this.router.navigate(['stocks']);
            },
            error => {
                this.toastrService.error($localize`Updating stock failed.`);
                console.error(error);
            }
        );
    }
}

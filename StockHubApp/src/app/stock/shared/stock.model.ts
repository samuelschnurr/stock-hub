import { Validators } from '@angular/forms';

export class Stock {
    public id = 0;
    public name = ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]];
    /** The amount of the stock units in the format 0.0000 */
    public amount = ['', [Validators.required, Validators.min(0.0001), Validators.max(9999999999999.9999)]];
    /** The acquisition price per unit in the currency format 0.0000 */
    public acquisitionPricePerUnit = ['', [Validators.required, Validators.min(0.0001), Validators.max(99999999.9999)]];
}

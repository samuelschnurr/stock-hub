export class PieChartData {
    /** The name of the chart entry. */
    public name: string;
    /** The value of the entry. */
    public value: number;

    /**
     * The default constructor for creating a new instance of PieChartData
     */
    public constructor(name: string, value: number) {
        this.name = name;
        this.value = value;
    }
}

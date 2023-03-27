import { RouteData } from '../../RouteData';

export class Tile {

    public GridWidth: number = 0;
    public GridHeight: number = 0;

    constructor(
        public RowIndex: number,
        public ColIndex: number,
        public RowSpan: number,
        public ColSpan: number,
        public Resizable: Boolean) {
    }

    Route: RouteData;
}
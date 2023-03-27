import { Tile } from './Tile';

export class TileLayoutConfig {
    Tiles: Array<Tile>;

    constructor(
        public Rows: number,
        public Cols: number
    ) {
        this.Tiles = new Array<Tile>();
    }

    AddTile(
        rowIndex: number,
        colIndex: number,
        rowSpan: number,
        colSpan: number,
        resizable: Boolean
    ): TileLayoutConfig {
        this.Tiles.push(new Tile(rowIndex, colIndex, rowSpan, colSpan, resizable));
        return this;
    }
}
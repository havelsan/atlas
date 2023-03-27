import { TileLayoutConfig } from './TileLayoutConfig';
import { Tile } from './Tile';

export class LayoutBuilder {
    static CreateTileLayout(rows: number, cols: number, ...tiles: Tile[]): TileLayoutConfig {
        return new TileLayoutConfig(rows, cols);
    }
}
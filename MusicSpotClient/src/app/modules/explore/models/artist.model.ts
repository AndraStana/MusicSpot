import { AlbumModel } from './album.model';

export class ArtistModel{
    id: string;
    name: string;
    urlPicture: string;
    albums: AlbumModel[];
}
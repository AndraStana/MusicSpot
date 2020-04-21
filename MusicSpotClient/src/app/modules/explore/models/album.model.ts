import { SongsimpleModel } from './song-simple-model';

export class AlbumModel{
    id: string;
    name: string;
    urlPicture: string;
    songs: SongsimpleModel[]
}
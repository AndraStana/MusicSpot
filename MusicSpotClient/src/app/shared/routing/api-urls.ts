export enum ApplicationAPI {
    ACCOUNT_LOGIN = "Account/Login",
    ACCOUNT_REGISTER = "Account/Register",
    ACCOUNT_LOGOUT = "Account/Logout",

    LIBRARY_GET_SONGS = "Library/GetLibrarySongs",
    LIBRARY_GET_POPULARITY_RANKINGS = "Library/GetPopularityRankings",
    LIBRARY_ADD_SONG = "Library/AddSongToLibrary",
    LIBRARY_REMOVE_SONG = "Library/RemoveSongFromLibrary",

    FRIENDS_GET_FRIENDS = "Friends/GetFriends",
    FRIENDS_GET_ALL_POSSIBLE_FRIENDS = "Friends/GetAllPossibleFriends",
    FRIENDS_ADD_FRIEND = "Friends/AddFriend",
    FRIENDS_REMOVE_FRIEND = "Friends/RemoveFriend",

    NEWS_GET_NEWS = "News/GetNews",

    RECOMMENDED_GET_RECOMMENDED_SONGS = "Recommended/GetRecommendedSongs",

    EXPLORE_GET_ARTISTS = "Explore/GetArtists"
    
}
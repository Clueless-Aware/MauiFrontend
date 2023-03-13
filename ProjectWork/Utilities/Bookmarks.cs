namespace ProjectWork.Utilities;

public static class Bookmarks
{
    public static async Task AddToBookmarks(int artworkId, string artworkTitle)
    {
        var result = await App.Authentication.AddBookMark(artworkId);
        if (!result.status || App.Authentication.UserSession.User is null)
        {
            await UtilityToolkit.CreateToast(
                $"There was an error in adding artwork {artworkTitle} to your account bookmarks... Please try again later");
            return;
        }

        await UtilityToolkit.CreateToast(
            $"Added {artworkTitle} as a bookmarked artwork in {App.Authentication.UserSession.User.Username} list");
    }

    public static async Task RemoveFromBookmarks(int artworkId, string artworkTitle)
    {
        var bookmarkId = (int)App.Authentication.UserSession.User.BookmarksIds
        [App.Authentication.UserSession.User.BookmarkedArtworks
            .FindIndex(artwork => artwork.Id == artworkId)];
        var result = await App.Authentication.RemoveBookmark(bookmarkId);
        if (!result.status || App.Authentication.UserSession.User is null)
        {
            await UtilityToolkit.CreateToast(
                $"There was an error in removing artwork {artworkTitle} to your account bookmarks... Please try again later");
            return;
        }

        await UtilityToolkit.CreateToast(
            $"Removed {artworkTitle} as a bookmarked artwork from {App.Authentication.UserSession.User.Username} list");
    }
}
 
CREATE PROCEDURE GetArtistDetails
    @artistID INT = NULL
AS
BEGIN
    IF NOT EXISTS(
            SELECT art.title AS ArtistTitle, art.biography AS ArtistBiography, art.heroURL AS artHeroURL, art.imageURL AS artImgUrl,
                alb.title AS albTitle, alb.imageURL AS albImageUrl, alb.year AS albYear,
                sg.title AS songTitle, sg.bpm AS sgBpm, sg.chart AS sgChart, sg.multitracks AS sgMultiTracks
       
                FROM Artist art
                LEFT JOIN Album alb ON art.artistID = alb.artistID
                LEFT JOIN Song sg ON art.artistID = sg.artistID
                WHERE art.artistID = @artistID
                )
             SET @artistID = 1;


    SELECT art.title AS ArtistTitle, art.biography AS ArtistBiography, art.heroURL AS artheroURL, art.imageURL AS artImgUrl,
           alb.title AS albTitle, alb.imageURL AS albImageUrl, alb.year AS albYear,
           sg.title AS songTitle, sg.bpm AS sgBpm, sg.chart AS sgChart, sg.multitracks AS sgMultiTracks
       
    FROM Artist art
    LEFT JOIN Album alb ON art.artistID = alb.artistID
    LEFT JOIN Song sg ON art.artistID = sg.artistID
    WHERE art.artistID = @artistID
END

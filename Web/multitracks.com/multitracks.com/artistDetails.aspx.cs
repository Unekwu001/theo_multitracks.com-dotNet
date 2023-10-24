using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class artistDetails : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e )
	{
		var sql = new SQL();

		if (!IsPostBack)
		{
			if (int.TryParse(Request.QueryString["artistID"], out int artistID))
			{
				// Create the SQL parameter for artistID
				var artistIDParam = new SqlParameter("@artistID", SqlDbType.Int);
				artistIDParam.Value = artistID;

				// Add the parameter to the SQL parameters collection
				sql.Parameters.Add(artistIDParam);

				//One-time pulling from stored procedure
				DataTable artistCompleteData = sql.ExecuteStoredProcedureDT("GetArtistDetails");

				//For top banner and all other details within it.
				BannerDetailsAndBiography(artistCompleteData);

				//for The Top Songs Division
				topSongs_Div(artistCompleteData);

				//for all the Artist's albums
				AllAlbums(artistCompleteData);
			}

		}
	}







	private void BannerDetailsAndBiography(DataTable AllData)
	{
		if (AllData.Rows.Count > 0)
		{
			var artistheroUrl = AllData.Rows[0]["artHeroURL"].ToString();
			heroArtist.ImageUrl = artistheroUrl;

			var artistimgUrl = AllData.Rows[0]["artImgUrl"].ToString();
			imgArtist.ImageUrl = artistimgUrl;

			var artistname = AllData.Rows[0]["ArtistTitle"].ToString();
			titleArtist.Text = artistname;

			var biography = AllData.Rows[0]["ArtistBiography"].ToString();
			bioArtist.Text = biography;
		}
		else
		{
			// Handle the case when artistID is not found or is null
			// Set a default image or display an error message
		}
	}


	private void topSongs_Div(DataTable AllData) 
	{
		if (AllData.Rows.Count > 0)
		{
			 
			// Bind the Repeater control to the data source
			songRepeater.DataSource = AllData;
			songRepeater.DataBind();
		}
		else
		{
			// Handle the cases where artistID is not found or is null
			// Set a default image or display an error message
		}
	}


	private void AllAlbums(DataTable AllData)
	{
		if (AllData.Rows.Count > 0)
		{
			// Bind the Repeater control to the data source
			albumRepeater.DataSource = AllData;
			albumRepeater.DataBind();
		}
		else
		{
			// Handle the cases where artistID is not found or is null
		}
	}


}

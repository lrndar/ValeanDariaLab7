using System;
using Microsoft.Maui.Controls;
using ValeanDariaLab7.Models;

namespace ValeanDariaLab7
{

	public partial class ProductPage : ContentPage
	{
		ShopList sl;
		public ProductPage(ShopList slist)
		{
			InitializeComponent();
			sl = slist;
		}
		async void OnSaveButtonClicked(object sender, EventArgs e)
		{
			var product = (Product)BindingContext;
			await App.Database.SaveProductAsync(product);
			listView.ItemsSource = await App.Database.GetProductsAsync();
		}
		async void OnDeleteButtonClicked(object sender, EventArgs e)
		{
			var product = listView.SelectedItem as Product;
			await App.Database.DeleteProductAsync(product);
			listView.ItemsSource = await App.Database.GetProductsAsync();
		}
		protected override async void OnAppearing()
		{
			base.OnAppearing();
			var shopl = (ShopList)BindingContext;
			listView.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
		}
		async void OnChooseButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ProductPage((ShopList)
		   this.BindingContext)
			{
				BindingContext = new Product()
			});

		}

		private void OnAddButtonClicked(object sender, EventArgs e)
		{
			// Add your logic for handling the Add to Shop List button click here.
		}
	}
}
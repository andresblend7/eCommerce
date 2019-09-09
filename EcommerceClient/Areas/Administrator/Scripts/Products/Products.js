let ProductAppVue = new Vue({
    el: '#products-app',
    data: {
        products: [{}],
        cities: [{}],
        categories: [{}],
        subCategories: [{}],
        product: {
            id: null,
            categoryId: 0
        },
        //Flag para modal de ditar o crear
        flagEdit: false,
        loading: false,
        productTarget: 0,
        succsessMsg: "default"
    },
    methods: {

        getSubCategories: function () {
            console.log("get", this.product.categoryId);

            //Realizamos la petición
            $Core.Ajax("Categories", "GetSubCategoriesByCategory", { idCategoria: this.product.categoryId }, function ($response) {

                
                if ($response.control) {

                    console.log($response);
                    ProductAppVue.subCategories = $response.data;

                } else {
                    alert("Error");
                }

                ProductAppVue.loading = false;

            },
                ($response) => alert("ERROR ", $response));

        },

        initData: function ($model) {
            
            this.products = $model.products;
            this.cities = $model.cities;
            this.categories = $model.categories;

            console.log($model);
        }
    }
});
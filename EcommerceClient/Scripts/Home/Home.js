let vueHome = new Vue({
    el: '#home-view',
    data: {
        msg: 'eCommerce',
        cities: [{}],
        categories: [{}],
        products: [{}]
    },
    methods: {
        getProduct: function ($product) {
            window.location.href = $url+'Home/ProductInfo?product=' + $product.guId;
        },
        goToSucategory:function ($subCategory) {
            window.location.href = 'home?idSubCategoria=' + $subCategory.id;
        },
        //Método encargado de inicializar la información.
        initData: function ($model) {

            //Ciudades 
            this.cities = $model.cities;
            this.categories = $model.categories;
            this.products = $model.products;

            console.log($model);
        },
        addToCart: function ($product) {

            vueAppMenu.addToCar($product);
        }

    },
    mounted: function () {
    }

});
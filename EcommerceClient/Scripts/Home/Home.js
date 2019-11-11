let vueHome = new Vue({
    el: '#home-view',
    data: {
        msg: 'eCommerce',
        cities: [{}],
        categories: [{}],
        products: [{}]
    },
    methods: {
        getByStatus: function (status) {
            let comodin = "";

      
            var actualLocation = window.location.href;
            actualLocation = actualLocation.replace("?estado=false", "");
            actualLocation = actualLocation.replace("?estado=true", "");
            actualLocation = actualLocation.replace("&estado=false", "");
            actualLocation = actualLocation.replace("&estado=true", "");
            console.log(actualLocation);


            if (actualLocation.indexOf('?') != -1) {
                // will not be triggered because str has _..
                comodin = "&";
            } else {

                comodin = "?";

            }


            window.location.href = actualLocation    + comodin + 'estado='+status;
           
        },
        getProduct: function ($product) {
            window.location.href = $url+'Home/ProductInfo?product=' + $product.guId;
        },
        goToSucategory:function ($subCategory) {
            window.location.href = $url+'/Home?idSubCategoria=' + $subCategory.id;
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
let vueHome = new Vue({
    el: '#home-view',
    data: {
        msg: 'eCommerce',
        cities: [{}],
        categories: [{}],
        products: [{}]
    },
    methods: {
        //Método encargado de inicializar la información.
        initData: function ($model) {

            //Ciudades 
            this.cities = $model.cities;
            this.categories = $model.categories;
            this.products = $model.products;

            console.log($model);
        }

    },
    mounted: function () {
    }

});
let vueHome = new Vue({
    el: '#home-view',
    data: {
        msg: 'eCommerce',
        cities: [{}]
    },
    methods: {
        //Método encargado de inicializar la información.
        initData: function ($model) {

            //Ciudades 
            this.cities = $model.cities;
        }

    },
    mounted: function () {
    }

});
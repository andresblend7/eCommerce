let vueProductInfo = new Vue({
    el: '#productinfo-view',
    data: {
        msg: 'eCommerce',
        product: {}
    },
    methods: {

        initData: function ($model) {

         
            this.product = $model.product;

            console.log($model);
        },
        addToCart: function ($product) {

            vueAppMenu.addToCar($product);
        }

    },
    mounted: function () {
    }

});
    

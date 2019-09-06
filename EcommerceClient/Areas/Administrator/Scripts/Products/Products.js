let ProductAppVue = new Vue({
    el: '',
    data: {
        products: [{}],
        Product: {
            id:null
        },
        //Flag para modal de ditar o crear
        flagEdit: false,
        loading: false,
        productTarget: 0,
        succsessMsg: "default"
    },
    methods: {

        initData: function ($model) {
            
            this.products = $model.products;
            console.log(this.products);
        }
    }
});
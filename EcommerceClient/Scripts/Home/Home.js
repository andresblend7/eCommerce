let vueHome = new Vue({
    el: '#home-view',
    data: {
        return :{
            msg: 'eCommerce',
            cities: $model.Cities
        }
    },
    mounted: function () {
        console.log(this.cities);
    }

});
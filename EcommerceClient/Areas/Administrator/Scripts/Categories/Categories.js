let categoriesAppVue = new Vue({
    el: '#categories-app',
    data: {
        categories: [{}],
        category: {
            name: null,
            description: null,
            state:true
        }


    },
    methods: {

        createCategory: function () {

            console.log($Core.PrepareObject(this.category));

/*
            $Core.Ajax("Administrator/Categories", "Create", { this. }, function ($respuesta) {
                console.log($respuesta);

                if ($respuesta.control) {
                    vueAppMenu.logginMsg = "Usuario autenticado correctamente.";
                    setTimeout(() => location.reload(), 1200);
                } else {
                    vueAppMenu.logginMsg = "Usuario no existe";
                }

            }, function ($respuesta) {

                alert("ERROR ", $respuesta);

            });
            */
        },

        initData: function ($model) {

            console.log($model.categories);

            this.categories = $model.categories;

        }

    }

});
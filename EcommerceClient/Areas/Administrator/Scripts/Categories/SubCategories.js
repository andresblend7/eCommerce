let subCategoriesAppVue = new Vue({
    el: '#subcategories-app',
    data: {
        subcategory: {
            id: null,
            name: null,
            categoryId: 0,
            description: null,
            status:true
        },
        categories:[],
        subCategories: [],
        flagEdit: false,
        loading: false,
        succsessMsg:"default"

    }, methods : {


        //Método encargado de la creación y actualización de la categoria
        processSubCategory: function () {

            this.loading = true;

            //Realizamos el UpperCase CamellCase
            $Core.PrepareObject(this.subcategory);

            if (!this.flagEdit) {
                //Creación de una categoria

                //Realizamos la petición
                $Core.Ajax("Categories", "AddSubCategory", this.subcategory, function ($response) {

                    //Validamos la creación de la categoria
                    if ($response.control) {

                        $("#modalCreate").modal("hide");

                        menuAdminVueApp.succsessMsg = "Subcategoria creada satisfactoriamente.";

                        $("#resultModal").modal("show");

                        //Actualizamos la página
                        setTimeout(() => $Core.ReloadPage(), 1700);

                    } else {
                        alert("Error");
                    }

                    categoriesAppVue.loading = false;

                },
                    ($response) => alert("ERROR ", $response));
            }
            else {
                //Edición de una categoria

                //Realizamos la petición
                $Core.Ajax("Categories", "Update", this.category, function ($response) {

                    //Validamos la creación de la categoria
                    if ($response.control) {

                        $("#modalCreate").modal("hide");

                        categoriesAppVue.succsessMsg = "SubCategoría actualizada satisfactoriamente.";

                        $("#successCategory").modal("show");

                        //Actualizamos la página
                        setTimeout(() => $Core.ReloadPage(), 1700);

                    } else {
                        alert("Error");
                    }

                    categoriesAppVue.loading = false;

                },
                    ($response) => alert("ERROR ", $response));

            }


        },

        initData: function ($model) {
            console.log($model);

            this.subCategories = $model.subCategories;
            this.categories = $model.categories;

        }
    }

});
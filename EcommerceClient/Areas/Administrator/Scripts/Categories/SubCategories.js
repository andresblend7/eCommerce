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
        subcategoryTarget: 0,
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
                $Core.Ajax("Categories", "UpdateSubCategory", this.subcategory, function ($response) {

                    //Validamos la creación de la categoria
                    if ($response.control) {

                        $("#modalCreate").modal("hide");

                        menuAdminVueApp.succsessMsg = "Subcategoria Actualizada satisfactoriamente.";

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

        },

        setTarget: function ($target) {
            this.subcategoryTarget = $target.id;

            Object.assign(this.subcategory, $target);

            this.flagEdit = true;
        },

        changeStatus: function ($subCategory, $index) {

            console.log($subCategory);

            //Realizamos la petición
            $Core.Ajax("Categories", "ChangeStatusSubCategory", { id: $subCategory.id }, function ($response) {

                //Validamos la creación de la categoria
                if ($response.control) {

                    $Core.Notificate('success', 'Estado actualizado');

                    //Actualizamos el objeto
                    subCategoriesAppVue.subCategories[$index].status = !$subCategory.status;

                } else {
                    $Core.Notificate('error', 'Ocurrió un error en la solicitud');
                }

            }, function ($response) {

                alert("ERROR ", $response);

            });

        },

        initData: function ($model) {
            console.log($model);

            this.subCategories = $model.subCategories;
            this.categories = $model.categories;

        }
    }

});
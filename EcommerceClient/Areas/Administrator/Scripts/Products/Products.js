let ProductAppVue = new Vue({
    el: '#products-app',
    data: {
        products: [{}],
        cities: [{}],
        categories: [{}],
        subCategories: [{}],
        product: {
            id: 0,
            name: '',
            description: '',
            categoryId: 0,
            guId: 'guuuid',
            condition: true,
            price: null,
            cityId: 1,
            stock: null,
            subCategoryId : 0
        },
        outlet: {
            target: 0,
            value: 30,
            idx: -1,
            base: 0
        },
        //Flag para modal de ditar o crear
        flagEdit: false,
        loading: false,
        productTarget: 0,
        succsessMsg: "default"
    },
    methods: {
        //Método encargado de la creación y actualización de un producto
        processProduct: function () {

            this.loading = true;

            //Realizamos el UpperCase CamellCase
            $Core.PrepareObject(this.product);


            if (!this.flagEdit) {
                //Creación de un producto

                //Agregamos la imágen primero
                var $dataImg = new FormData();
                jQuery.each(jQuery('#imgprincipal')[0].files, function (i, file) {
                    $dataImg.append('file-' + i, file);
                });

                $Core.UploadFile("SaveImageProduct", $dataImg, function ($response) {

                    //Sí se creo la imagen se crea el producto
                    if ($response.control) {

                        ProductAppVue.product.principalImage = $response.data;

                        ProductAppVue.createProduct();
                    } else {
                        alert("Error");
                    }

                    ProductAppVue.loading = false;

                },
                    ($response) => alert("ERROR ", $response));

            }
            else {
                //Edición de una categoria

                //Realizamos la petición
                $Core.Ajax("Products", "Update", this.product, function ($response) {

                    //Validamos la creación de la categoria
                    if ($response.control) {

                        $("#modalCreate").modal("hide");

                        ProductAppVue.succsessMsg = "Producto actualizado satisfactoriamente.";

                        $("#successCategory").modal("show");

                        //Actualizamos la página
                        setTimeout(() => $Core.ReloadPage(), 1700);

                    } else {
                        alert("Error");
                    }

                    ProductAppVue.loading = false;

                },
                    ($response) => alert("ERROR ", $response));

            }


        },

        restartProduct: function () {
            this.product = {
                id: 0,
                name: '',
                description: '',
                categoryId: 0,
                guId: 'guuuid',
                condition: true,
                price: null,
                cityId: 1,
                stock: null,
                subCategoryId: 0
            }

            this.flagEdit = false;
        },

        createProduct: function () {


            console.log("creando => ", this.product);


            //Realizamos la petición
            $Core.Ajax("Products", "Create", this.product, function ($response) {

                //Validamos la creación de la categoria
                if ($response.control) {

                    $("#modalCreate").modal("hide");

                    ProductAppVue.succsessMsg = "Producto creado satisfactoriamente.";

                    $("#successCategory").modal("show");

                    //Actualizamos la página
                    setTimeout(() => $Core.ReloadPage(), 1700);

                } else {
                    alert("Error");
                }

                ProductAppVue.loading = false;

            },
                ($response) => alert("ERROR ", $response));
        },

        deleteProduct: function () {

            this.loading = true;

            console.log(this.categoryTarget);

            if (this.categoryTarget != 0) {
                //Realizamos la petición
                $Core.Ajax("Products", "Delete", { id: this.productTarget }, function ($response) {

                    //Validamos la eliminación de la categoria
                    if ($response.control) {
                        $("#modalConfirmacion").modal("hide");

                        ProductAppVue.succsessMsg = "Producto eliminado satisfactoriamente.";

                        $("#successCategory").modal("show");

                        //Actualizamos la página
                        setTimeout(() => $Core.ReloadPage(), 1700);


                    } else {

                    }

                    this.loading = false;

                }, function ($response) {

                    alert("ERROR ", $response);

                });
            }

        },

        removeDiscount: function ($product) {

            if (!$product.isOutlet)
                return false;
            //Realizamos la petición
            $Core.Ajax("Products", "RemoveDiscount", { id: $product.id }, function ($response) {

                //Validamos la creación de la categoria
                if ($response.control) {

                    $Core.Notificate('success', 'Descuento Removido');

                    //Actualizamos la página
                    setTimeout(() => $Core.ReloadPage(), 850);

                } else {
                    $Core.Notificate('error', 'Ocurrió un error en la solicitud');
                }

            }, function ($response) {


                //Actualizamos el objeto
                ProductAppVue.products[0].status = true;
                alert("ERROR ", $response);


            });
        },

        setOutletTarget: function ($product, $idx) {
            this.outlet.target = $product.id;
            this.outlet.idx = $idx;
            this.outlet.base = $product.price;
        },

        applyDiscount: function () {
            //Realizamos la petición
            $Core.Ajax("Products", "ApplyDiscount", { id: this.outlet.target, discount: this.outlet.value }, function ($response) {

                //Validamos la creación de la categoria
                if ($response.control) {

                    $Core.Notificate('success', 'Descuento aplicado');

                    //Actualizamos la página
                    setTimeout(() => $Core.ReloadPage(), 850);

                } else {
                    $Core.Notificate('error', 'Ocurrió un error en la solicitud');
                }

            }, function ($response) {


                //Actualizamos el objeto
                ProductAppVue.products[0].status = true;
                alert("ERROR ", $response);


            });
        },

        getSubCategories: function () {
            console.log("get", this.product.categoryId);

            //Realizamos la petición
            $Core.Ajax("Categories", "GetSubCategoriesByCategory", { idCategoria: this.product.categoryId }, function ($response) {


                if ($response.control) {

                    console.log($response);
                    ProductAppVue.subCategories = $response.data;

                } else {
                    alert("Error");
                }

                ProductAppVue.loading = false;

            },
                ($response) => alert("ERROR ", $response));

        },

        changeStatus: function ($product, $index) {

            //Realizamos la petición
            $Core.Ajax("Products", "ChangeStatus", { id: $product.id }, function ($response) {

                //Validamos la creación de la categoria
                if ($response.control) {

                    $Core.Notificate('success', 'Estado actualizado');

                    //Actualizamos el objeto
                    ProductAppVue.products[$index].status = !$product.status;

                } else {
                    $Core.Notificate('error', 'Ocurrió un error en la solicitud');
                }

            }, function ($response) {


                //Actualizamos el objeto
                ProductAppVue.products[0].status = true;
                alert("ERROR ", $response);


            });

        },


        setTarget: function ($target) {
            this.productTarget = $target.id;

            Object.assign(this.product, $target);

            this.flagEdit = true;
        },

        initData: function ($model) {

            this.products = $model.products;
            this.cities = $model.cities;
            this.categories = $model.categories;

            console.log(this.product);
        }
    }
});
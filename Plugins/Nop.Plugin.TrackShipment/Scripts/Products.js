
$(document).ready(function () {
    GetToken();
    ShowOrHidePopup(false);
});
var userName = "alireza@gmail.com";
var password = "123456";
var token;

function GetToken() {
    if (!userName || !password) {
        console.log("username or password null");
        return;
    }
    $.ajax({
        cache: false,
        type: 'Post',
        headers: {
            "accept": "text/plain",
            "Content-Type": "application/json",
        },
        data: JSON.stringify({
            "guest": true,
            "username": userName,
            "password": password,
            "remember_me": true
        }),
        url: "/token",
        success: function (response) {
            token = response.access_token;
            GetProducts();
            console.log(token);
        }
    });
}

function GetProducts() {
    var _url = "/api/products";
    $.ajax({
        cache: false,
        type: "GET",
        headers: {
            Authorization: "Bearer " + token,
        },
        url: _url,
        success: function (response) {
            response = response.products;
            var holderTempelet = $("#table_holder");
            $("#table_holder").empty();
            for (let i = 0; i < response.length; i++) {
                var appendTempelet = $("#table_append").html();
                appendTempelet = appendTempelet.replace(/#Id#/g, response[i].id)
                    .replace(/#Index#/g, i + 1)
                    .replace(/#Image#/g, "Image")
                    .replace(/#Name#/g, response[i].name)
                    .replace(/#Sku#/g, response[i].sku)
                    .replace(/#Price#/g, response[i].price)
                    .replace(/#StockQuantity#/g, response[i].stock_quantity);
                holderTempelet.append(appendTempelet);
            }
        }
    });
}

function ShowOrHidePopup(show) {
    var popup = $("#create_popup");
    if (show == true) {
        popup.css("display", "block");
    }
    else {
        popup.css("display", "none");
    }
}

function GetProductByCategoty() {
    var _url = "/api/products/categories";
    $.ajax({
        caches: false,
        type: "GET",
        headers: {
            Authorization: "Bearer " + token,
        },
        url: _url,
        success: function (response) {

        }
    });
}

function GetCount() {
    var _url = "/api/products/count";
    $.ajax({
        caches: false,
        type: "GET",
        headers: {
            Authorization: "Bearer " + token,
        },
        url: _url,
        success: function (response) {

        }
    });
}

function Save() {
    var _url = "/api/products";
    var _id = $("#txtId").val();
    var _name = $("#txtName").val().toString();
    var _sku = $("#txtSku").val().toString();
    var _price = $("#txtSku").val();
    var _stock_quantity = $("#txtStockQuantity").val();
    var p =
    {
        "visible_individually": true,
        "name": _name,
        "short_description": "",
        "full_description": "",
        "show_on_home_page": false,
        "meta_keywords": "",
        "meta_description": "",
        "meta_title": "",
        "allow_customer_reviews": true,
        "approved_rating_sum": 0,
        "not_approved_rating_sum": 0,
        "approved_total_reviews": 0,
        "not_approved_total_reviews": 0,
        "sku": _sku,
        "manufacturer_part_number": "",
        "gtin": "",
        "is_gift_card": false,
        "require_other_products": false,
        "automatically_add_required_products": false,
        "required_product_ids": [
            0
        ],
        "is_download": false,
        "unlimited_downloads": false,
        "max_number_of_downloads": 0,
        "download_expiration_days": 0,
        "has_sample_download": false,
        "has_user_agreement": false,
        "is_recurring": false,
        "recurring_cycle_length": 0,
        "recurring_total_cycles": 0,
        "is_rental": false,
        "rental_price_length": 0,
        "is_ship_enabled": false,
        "is_free_shipping": false,
        "ship_separately": false,
        "additional_shipping_charge": 0,
        "is_tax_exempt": false,
        "tax_category_id": 0,
        "is_telecommunications_or_broadcasting_or_electronic_services": false,
        "use_multiple_warehouses": false,
        "manage_inventory_method_id": 0,
        "stock_quantity": _stock_quantity,
        "display_stock_availability": true,
        "display_stock_quantity": true,
        "min_stock_quantity": 0,
        "low_stock_activity_id": 0,
        "notify_admin_for_quantity_below": 0,
        "allow_back_in_stock_subscriptions": true,
        "order_minimum_quantity": 0,
        "order_maximum_quantity": 0,
        "allowed_quantities": "string",
        "allow_adding_only_existing_attribute_combinations": true,
        "disable_buy_button": false,
        "disable_wishlist_button": false,
        "available_for_pre_order": true,
        "pre_order_availability_start_date_time_utc": "2023-08-21T08:37:45.114Z",
        "call_for_price": true,
        "price": _price,
        "old_price": 0,
        "product_cost": 0,
        "special_price": 0,
        "special_price_start_date_time_utc": "2023-08-21T08:37:45.114Z",
        "special_price_end_date_time_utc": "2023-08-21T08:37:45.114Z",
        "customer_enters_price": true,
        "minimum_customer_entered_price": 0,
        "maximum_customer_entered_price": 0,
        "baseprice_enabled": true,
        "baseprice_amount": 0,
        "baseprice_base_amount": 0,
        "has_tier_prices": false,
        "has_discounts_applied": false,
        "weight": 0,
        "length": 0,
        "width": 0,
        "height": 0,
        "available_start_date_time_utc": "2023-08-21T08:37:45.114Z",
        "available_end_date_time_utc": "2023-08-21T08:37:45.114Z",
        "display_order": 0,
        "published": true,
        "deleted": false,
        "created_on_utc": "2023-08-21T08:37:45.114Z",
        "updated_on_utc": "2023-08-21T08:37:45.114Z",
        "product_type": "string",
        "parent_grouped_product_id": 0,
        "role_ids": [
            0
        ],
        "discount_ids": [
            0
        ],
        "store_ids": [
            0
        ],
        "manufacturer_ids": [
            0
        ],
        "images": [
            0
        ],
        "attributes": [
            0
        ],
        "product_attribute_combinations": [
            0
        ],
        "product_specification_attributes": [
            0
        ],
        "associated_product_ids": [
            0
        ],
        "tags": [
            "new"
        ],
        "vendor_id": 0,
        "se_name": "",
        "id": _id
    }
    if (!_id) {
        _id = 0;
    }
    if (_id > 0) {
        _url = _url + _id;
        $.ajax({
            caches: false,
            type: "PUT",
            headers: {
                Authorization: "Bearer " + token,
                accept: "text/plain",
                "Content-Type": "application/json",
            },
            url: _url,
            data: JSON.stringify(p),
            success: function (response) {
                if (response) {
                    console.log("update success !");
                }
            }
        });
    }
    else {
        $.ajax({
            caches: false,
            type: "POST",
            headers: {
                Authorization: "Bearer " + token,
                "accept": "text/plain",
                "Content-Type": "application/json",
            },
            url: _url,
            data: JSON.stringify(p),
            success: function (response) {
                if (response) {
                    console.log("insert success !");
                }
            }
        });
    }
}

function Delete() {
    var _url = "/api/products/{id}";
    $.ajax({
        caches: false,
        type: "POST",
        headers: {
            Authorization: "Bearer " + token,
        },
        url: _url,
        success: function (response) {

        }
    });
}

function Update(id) {
    var product = {};
    var _url = "/api/products/" + id;
    $.ajax({
        caches: false,
        type: "GET",
        headers: {
            Authorization: "Bearer " + token,
        },
        data: { id: id },
        url: _url,
        success: function (response) {
            product = response.products[0];
            $("#txtId").val(product.id);
            $("#txtName").val(product.name);
            $("#txtSku").val(product.sku);
            $("#txtPrice").val(product.price);
            $("#txtStockQuantity").val(product.stock_quantity);
            $("#product_img").attr("src", product.images[0].src);
            ShowOrHidePopup(true);
            $("#txtName").focus();
        }
    });
    console.log(product);
   
}
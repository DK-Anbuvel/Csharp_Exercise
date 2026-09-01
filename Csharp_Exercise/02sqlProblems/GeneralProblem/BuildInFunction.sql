

/* OFFSET and FETCH Clause */

/* skip the first 10 product and return the rest */

SELECT
    product_name,
    list_price
FROM
    production.products
ORDER BY
    list_price,
    product_name 
OFFSET 10 ROWS;

/* To skip the first 10 products and select the next 10 products */

SELECT
    product_name,
    list_price
FROM
    production.products
ORDER BY
    list_price,
    product_name 
OFFSET 10 ROWS 
FETCH NEXT 10 ROWS ONLY;

/*to get the top N rows/ to retrieve the top 10 most expensive products from the products table */
SELECT
    product_name,
    list_price
FROM
    production.products
ORDER BY
    list_price DESC,
    product_name 
OFFSET 0 ROWS  /* skip the 0 rows */
FETCH FIRST 10 ROWS ONLY;/* retrieve first 10 products */
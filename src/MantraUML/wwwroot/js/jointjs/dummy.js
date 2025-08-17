const dummyData = [
    {
        label: 'Product',
        position: {x: 602, y: 8},
        attributes: [
            {name: 'id', type: 'Long', visibility: '-'},
            {name: 'name', type: 'String', visibility: '-'},
            {name: 'price', type: 'Double', visibility: '-'},
            {name: 'stock', type: 'Long', visibility: '-'},
            {name: 'createdAt', type: 'Instant', visibility: '-'},
            {name: 'deletedAt', type: 'Instant', visibility: '-'},
        ]
    },
    {
        label: 'ProductType',
        position: {x: 850, y: 10},
        attributes: [
            {name: 'id', type: 'Long', visibility: '-'},
            {name: 'name', type: 'String', visibility: '-'},
            {name: 'createdAt', type: 'Instant', visibility: '-'},
            {name: 'deletedAt', type: 'Instant', visibility: '-'},
        ]
    },
    {
        label: 'Order',
        position: {x: 102, y: 36},
        attributes: [
            {name: 'id', type: 'Long', visibility: '-'},
            {name: 'buyerId', type: 'String', visibility: '-'},
            {name: 'createdAt', type: 'Instant', visibility: '-'},
        ]
    },
    {
        label: 'OrderItem',
        position: {x: 357, y: 46},
        attributes: [
            {name: 'id', type: 'Long', visibility: '-'},
            {name: 'quantity', type: 'Long', visibility: '-'},
        ]
    },
    {
        label: 'OrderStatus',
        position: {x: 101, y: 229},
        attributes: [
            {name: 'id', type: 'Long', visibility: '-'},
            {name: 'name', type: 'String', visibility: '-'},
            {name: 'createdAt', type: 'Instant', visibility: '-'},
            {name: 'deletedAt', type: 'Instant', visibility: '-'},
        ]
    },
    {
        label: 'Cart',
        position: {x: 850, y: 260},
        attributes: [
            {name: 'buyerId', type: 'String', visibility: '-'},
        ]
    },
    {
        label: 'CartItem',
        position: {x: 610, y: 250},
        attributes: [
            {name: 'id', type: 'String', visibility: '-'},
            {name: 'quantity', type: 'Long', visibility: '-'},
        ]
    },
];

dummyData.forEach(data => {
    const class_ = createClass({
        position: {x: data.position.x, y: data.position.y},
        label: data.label,
        attributes: data.attributes,
    });
    graph.addCell(class_);
});

const link1 = new ArrowLink();
link1.source(getElementByLabel('Order'), {port: 'bottom-4'});
link1.target(getElementByLabel('OrderStatus'), {port: 'top-4'});
link1.addTo(graph);

const link2 = new CompositionArrowLink();
link2.source(getElementByLabel('Order'), {port: 'right-4'});
link2.target(getElementByLabel('OrderItem'), {port: 'left-5'});
link2.addTo(graph);

const link3 = new ArrowLink();
link3.source(getElementByLabel('OrderItem'), {port: 'right-5'});
link3.target(getElementByLabel('Product'), {port: 'left-4'});
link3.addTo(graph);

const link4 = new ArrowLink();
link4.source(getElementByLabel('Product'), {port: 'right-4'});
link4.target(getElementByLabel('ProductType'), {port: 'left-5'});
link4.addTo(graph);

const link5 = new CompositionArrowLink();
link5.source(getElementByLabel('Cart'), {port: 'left-5'});
link5.target(getElementByLabel('CartItem'), {port: 'right-5'});
link5.addTo(graph);

const link6 = new ArrowLink();
link6.source(getElementByLabel('CartItem'), {port: 'top-4'});
link6.target(getElementByLabel('Product'), {port: 'bottom-4'});
link6.addTo(graph);
class Class extends joint.dia.Element {
    constructor(options = {}) {
        const cc = options.attributes.length;
        const width = getLongestTextWidth(options.label, options.attributes) + 22;
        const height = cc > 0 ? (30 + 8 + 10 * cc + 10 * (cc - 1) + 12) : 30;
        super({
            ...options,
            markup: createMarkup(options),
            type: 'mantraUML.Class',
            position: options.position,
            size: {
                width: width,
                height: height
            },
            attrs: {
                'body': {
                    width: width,
                    height: height,
                    fill: '#fff',
                    stroke: '#000',
                    strokeWidth: 1,
                },
                'title': {
                    x: width / 2,
                    y: 18,
                    textAnchor: 'middle',
                    fontFamily: 'Verdana, sans-serif',
                    fontSize: 13,
                    fontWeight: 'bold',
                    fill: '#333',
                    text: options.label,
                },
                'line': {
                    x1: 0,
                    x2: width,
                    y1: 30,
                    y2: 30,
                    stroke: '#000',
                    strokeWidth: 1
                },
                ...createFieldAttrs(options)
            },
            ports: {
                groups: {
                    'top': {
                        position: 'top',
                        markup: [{tagName: 'circle', selector: 'portBody'}],
                        attrs: {portBody}
                    },
                    'right': {
                        position: 'right',
                        markup: [{tagName: 'circle', selector: 'portBody'}],
                        attrs: {portBody}
                    },
                    'bottom': {
                        position: 'bottom',
                        markup: [{tagName: 'circle', selector: 'portBody'}],
                        attrs: {portBody}
                    },
                    'left': {
                        position: 'left',
                        markup: [{tagName: 'circle', selector: 'portBody'}],
                        attrs: {portBody}
                    }
                }
            },
        });
    }
}

const portBody = {
    magnet: true,
    r: 1,
    fill: 'rgba(0,0,0,0)',
    stroke: 'rgba(0,0,0,0)',
    strokeWidth: 1
}

function createMarkup(options) {
    let markup = [{
        tagName: 'g',
        children: [
            {tagName: 'rect', selector: 'body'},
            {tagName: 'text', selector: 'title'},
            {tagName: 'line', selector: 'line'},
        ]
    }];
    for (let i = 1; i <= options.attributes.length; i++) {
        markup[0].children.push({
            tagName: 'text',
            selector: `field-${i}`,
        });
    }
    return markup;
}

function createFieldAttrs(options) {
    let attrs = {};
    for (let i = 1; i <= options.attributes.length; i++) {
        attrs[`field-${i}`] = {
            x: 10,
            y: 40 + 10 * i + 10 * (i - 1),
            width: 40,
            height: 30,
            fontFamily: 'Verdana, sans-serif',
            fontSize: 12,
            fill: '#900600',
            text: '- ' + options.attributes[i - 1].name + ': ' + options.attributes[i - 1].type,
        };
    }

    return attrs;
}

function createPorts(width, height) {
    const ports = [];
    ['top', 'bottom'].forEach(side => {
        for (let i = 0; i <= 8; i++) {
            ports.push({
                group: side,
                id: `${side}-${i}`,
                args: {x: i / 8 * width},
            });
        }
    });
    ['left', 'right'].forEach(side => {
        for (let i = 1; i < 8; i++) {
            ports.push({
                group: side,
                id: `${side}-${i}`,
                args: {y: i / 8 * height}
            });
        }
    });
    return ports;
}

function createClass(options) {
    const class_ = new Class(options);
    const ports = createPorts(class_.size().width, class_.size().height);
    class_.addPorts(ports);
    return class_;
}
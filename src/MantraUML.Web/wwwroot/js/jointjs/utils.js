function measureText(svgDocument, text, attrs) {
    const vText = V('text').attr(attrs).text(text);
    vText.appendTo(svgDocument);
    const bbox = vText.getBBox();
    vText.remove();
    return bbox;
}

function getLongestTextWidth(title, attributes) {
    const svg = paper.svg;

    const measure = measureText(svg, title, {fontFamily: 'Verdana, sans-serif', fontSize: 13});
    let maxWidth = measure.width + 20;

    attributes.forEach(attr => {
        const text = attr.visibility + ' ' + attr.name + ': ' + attr.type;
        const width = measureText(svg, text, {fontFamily: 'Verdana, sans-serif', fontSize: 12}).width;
        if (width > maxWidth) {
            maxWidth = width;
        }
    });

    return maxWidth;
}

const getElementByLabel = (label) => {
    return graph.getElements().find(e => e.attributes.attrs['title'].text === label);
}

function addDefsToSvg() {
    const svg = paper.svg;
    let defs = svg.querySelector('defs');
    const xmlns = "http://www.w3.org/2000/svg";

    svg.style.background = 'linear-gradient(to bottom, #AAB9DC, #fff)';

    let gradient = document.createElementNS(xmlns, 'linearGradient');
    gradient.setAttribute('id', 'backgroundGradient');
    gradient.setAttribute('x1', '0%');
    gradient.setAttribute('y1', '0%');
    gradient.setAttribute('x2', '100%');
    gradient.setAttribute('y2', '0%');

    let stop1 = document.createElementNS(xmlns, 'stop');
    stop1.setAttribute('offset', '0%');
    stop1.setAttribute('style', 'stop-color:#E5DBCC; stop-opacity:1');
    gradient.appendChild(stop1);

    let stop2 = document.createElementNS(xmlns, 'stop');
    stop2.setAttribute('offset', '100%');
    stop2.setAttribute('style', 'stop-color:#FCF2E3; stop-opacity:1');
    gradient.appendChild(stop2);

    defs.appendChild(gradient);

    let filter = document.createElementNS(xmlns, 'filter');
    filter.setAttribute('id', 'shadow');
    filter.setAttribute('x', '-50%');
    filter.setAttribute('y', '-50%');
    filter.setAttribute('width', '200%');
    filter.setAttribute('height', '200%');

    let feDropShadow = document.createElementNS(xmlns, 'feDropShadow');
    feDropShadow.setAttribute('dx', '3');
    feDropShadow.setAttribute('dy', '3');
    feDropShadow.setAttribute('stdDeviation', '3');
    feDropShadow.setAttribute('flood-opacity', '0.4');
    filter.appendChild(feDropShadow);

    defs.appendChild(filter);
}

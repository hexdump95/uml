class BaseLink extends joint.shapes.standard.Link {
    defaults() {
        return joint.util.defaultsDeep({
            type: 'mantraUML.BaseLink',
            defaultLabel: {
                position: {
                    distance: 100,
                    args: {
                        absoluteDistance: true
                    }
                }
            },
            attrs: {
                line: {
                    stroke: '#000',
                    strokeWidth: 1,
                    targetMarker: {
                        'type': 'none', 
                    }
                }
            },
            connector: {
                name: 'jumpover',
            },
        }, super.defaults);
    }
}

const arrowElement = {
    'type': 'polyline',
    'fill': 'none',
    'points': '14,-6 0,0, 14,6',
    'width': 1,
    'height': 1,
    'stroke-width': 1,
    'stroke': '#000'
};

class ArrowLink extends BaseLink {
    defaults() {
        return joint.util.defaultsDeep({
            type: 'mantraUML.ArrowLink',
            attrs: {
                line: {
                    targetMarker: arrowElement,
                }
            },
        }, super.defaults());
    }
}

const aggregationElement = {
    'type': 'polygon',
    'fill': '#fff',
    'points': '0,0 10,-5 20,0 10,5',
    'width': 1,
    'height': 1,
    'stroke-width': 1,
    'stroke': '#000'
}

class AggregationArrowLink extends ArrowLink {
    defaults() {
        return joint.util.defaultsDeep({
            type: 'mantraUML.AggregationArrowLink',
            attrs: {
                line: {
                    sourceMarker: aggregationElement,
                }
            },
        }, super.defaults());
    }
}

class AggregationLink extends BaseLink {
    defaults() {
        return joint.util.defaultsDeep({
            type: 'mantraUML.AggregationLink',
            attrs: {
                line: {
                    sourceMarker: aggregationElement,
                }
            },
        }, super.defaults());
    }
}

const compositionElement = {
    'type': 'polygon',
    'fill': '#000',
    'points': '0,0 10,-5 20,0 10,5',
    'width': 1,
    'height': 1,
    'stroke-width': 1,
    'stroke': '#000'
}

class CompositionArrowLink extends ArrowLink {
    defaults() {
        return joint.util.defaultsDeep({
            type: 'mantraUML.CompositionArrowLink',
            attrs: {
                line: {
                    sourceMarker: compositionElement,
                }
            },
        }, super.defaults());
    }
}

class CompositionLink extends BaseLink {
    defaults() {
        return joint.util.defaultsDeep({
            type: 'mantraUML.CompositionLink',
            attrs: {
                line: {
                    sourceMarker: compositionElement,
                }
            },
        }, super.defaults());
    }
}

class DashLink extends BaseLink {
    defaults() {
        return joint.util.defaultsDeep({
            type: 'mantraUML.DashLink',
            attrs: {
                line: {
                    strokeDasharray: 6
                }
            },
        }, super.defaults());
    }
}

class DashArrowLink extends DashLink {
    defaults() {
        return joint.util.defaultsDeep({
            type: 'mantraUML.DashArrowLink',
            attrs: {
                line: {
                    targetMarker: arrowElement,
                }
            },
        }, super.defaults());
    }
}

const triangleElement = {
    'type': 'polygon',
    'fill': '#fff',
    'points': '17,-6.5 0,0 17,6.5',
    'width': 1,
    'height': 1,
    'stroke-width': 1,
    'stroke': '#000'
};

class RealizationLink extends DashLink {
    defaults() {
        return joint.util.defaultsDeep({
            type: 'mantraUML.RealizationLink',
            attrs: {
                line: {
                    targetMarker: triangleElement,
                }
            },
        }, super.defaults());
    }
}

class GeneralizationLink extends BaseLink {
    defaults() {
        return joint.util.defaultsDeep({
            type: 'mantraUML.GeneralizationLink',
            attrs: {
                line: {
                    targetMarker: triangleElement,
                }
            },
        }, super.defaults());
    }
}

class LinkFactory {
    static createLink(type) {
        switch (type) {
            case'mantraUML.DashLink':
            case 'dashlink':
                return new DashLink();

            case'mantraUML.AggregationLink':
            case 'aggregation':
                return new AggregationLink();

            case'mantraUML.CompositionLink':
            case 'composition':
                return new CompositionLink();

            case'mantraUML.GeneralizationLink':
            case 'generalization':
                return new GeneralizationLink();

            case'mantraUML.RealizationLink':
            case 'realization':
                return new RealizationLink();

            case'mantraUML.ArrowLink':
            case 'arrowlink':
                return new ArrowLink();

            case'mantraUML.DashArrowLink':
            case 'dasharrowlink':
                return new DashArrowLink();

            case'mantraUML.AggregationArrowLink':
            case 'arrowaggregation':
                return new AggregationArrowLink();

            case'mantraUML.CompositionArrowLink':
            case 'arrowcomposition':
                return new CompositionArrowLink();

            case'mantraUML.BaseLink':
            default:
                return new BaseLink();
        }
    }
}

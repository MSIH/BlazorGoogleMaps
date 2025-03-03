﻿namespace GoogleMapsComponents.Maps;

/// <summary>
/// MarkerClustererOptions object used to define the properties that can be passed to a MarkerClusterer.
/// </summary>
public class MarkerClustererOptions
{

    //[Obsolete("Not used. Will be removed in future releases")]
    //public int? MaxZoom { get; set; }

    //[Obsolete("Not used. Will be removed in future releases")]
    //public bool? AverageCenter { get; set; }

    /// <summary>
    /// Set this property to the number of markers to be processed in a single batch
    /// </summary>
    public int? BatchSize { get; set; }


    //[Obsolete("User RendererObjectName")]
    //public string? ClusterClass { get; set; }


    //[Obsolete("Not used. Will be removed in future releases")]
    //public bool? EnableRetinaIcons { get; set; }


    //[Obsolete("Not used. Will be removed in future releases")]
    //public int? GridSize { get; set; }


    //[Obsolete("Not used. Will be removed in future releases")]
    //public bool? IgnoreHidden { get; set; }


    //[Obsolete("Not used. Will be removed in future releases")]
    //public string ImagePath { get; set; } = "_content/BlazorGoogleMaps/m";


    //[Obsolete("Not used. Will be removed in future releases")]
    //public string? ImageExtension { get; set; }


    //[Obsolete("Not used. Will be removed in future releases")]
    //public int? MinimumClusterSize { get; set; }


    //[Obsolete("Use RendererObjectName")]
    //public List<MarkerClusterIconStyle>? Styles { get; set; }

    //[Obsolete("Not used. Will be removed in future releases")]
    //public string? Title { get; set; }


    //[Obsolete("Not used. Will be removed in future releases")]
    //public int? ZIndex { get; set; }

    /// <summary>
    /// Whether to zoom the map when a cluster marker is clicked. You may want to
    /// set this to `false` if you have installed a handler for the `click` event
    /// and it deals with zooming on its own.
    /// </summary>
    public bool? ZoomOnClick { get; set; }

    /// <summary>
    /// full js object name in dot notation from window, for the object containing the algorithm function for js-markerclusterer use in calculating clusters. 
    /// options built-in to js-markerclusterer include "markerClusterer.GridAlgorithm", "markerClusterer.NoopAlgorithm", and "markerClusterer.SuperClusterAlgorithm" (default)
    /// see: https://googlemaps.github.io/js-markerclusterer/ for latest options.
    /// </summary>
    public string? AlgorithmObjectName { get; set; }

    /// <summary>
    /// full js object name in dot notation from window, for the object containing the render function for js-markerclusterer to use in rendering cluster markers.
    /// js-markerclusterer only includes one renderer, DefaultRenderer which is a class and would need to be instantiated before it is referenced in this property.
    /// https://googlemaps.github.io/js-markerclusterer/public/renderers/
    /// https://github.com/rungwiroon/BlazorGoogleMaps/issues/202
    /// </summary>
    public string? RendererObjectName { get; set; }
}
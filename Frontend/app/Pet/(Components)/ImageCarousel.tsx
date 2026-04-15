"use client";
import React from 'react'

const ImageCarousel = () => {
  return (
      <div
                className="md:col-span-7 lg:col-span-8 bg-surface-container-lowest rounded-lg overflow-hidden editorial-shadow relative group">
                <div className="flex overflow-x-auto snap-x snap-mandatory hide-scrollbar scroll-smooth h-[600px]"
                    id="hero-carousel">
                    <div className="snap-center shrink-0 w-full h-full">
                        <img alt="Beau posing" className="w-full h-full object-cover"
                            src="https://lh3.googleusercontent.com/aida-public/AB6AXuD665-P5l9bOYDLHLK-OQQwC_R0giN_Ci9Mikliu72HKfepwY6Psd-xRh4cLx4BbRrKgH6FTK70axIu0fuCc3wHbbaACb3Kqt0dUdeGENV5HveqDb7xAzPBvst4H5B85239eDG9IeSy2gHww7bN5Wjii6wqyZwv1pDnOgaL-A0YZZVhs01dw3jHU7as6pLlFLtN4nJkCAiz5rp3TTX9IqiZC3hsO7cWcV2yuhojd2b_feRQxyCHlH0XjPrKbIG_yBjiq4tkfhtyVVc" />
                    </div>
                    <div className="snap-center shrink-0 w-full h-full">
                        <img alt="Beau sleeping" className="w-full h-full object-cover"
                            src="https://lh3.googleusercontent.com/aida-public/AB6AXuCpLkNWeK2PdlnG_uJLf_yvg0deiAFXnHdlY0fHs5uDAHKlnfBn9Ayqy8n_gtjuMZjFuQoC0YccakTLL9BpnE1ithqYd2BjY9x_KQbDDBqQJBbkw06ZfeIFYRkbO54skVMuN7m-M5za5muaZDccyDBBnpCJYvOVojiOumZxD6mOqUN2UYWxcdgGCN6Ta_u33jQYiinEr_By1PNG9uRpr0qb02JtTG9TpiQMYLyIM7PMvOpshCqxq2UCPCV_3OXO3UmENBYN2xrMv7g" />
                    </div>
                    <div className="snap-center shrink-0 w-full h-full">
                        <img alt="Beau playing" className="w-full h-full object-cover"
                            src="https://lh3.googleusercontent.com/aida-public/AB6AXuBVb9ZLAMWNmi18Rx0sW1z_ZRN94Ny5FzSL7yVBwmZLR21CGgjuE_naTU6Wbowy59PLuTZ4jy99KygyUJyqetsTN226THtprzW7hfC8vRq4cmLnVruLyqUANXP-IOE6SDjQH2aMcziz8XeAuISz7SmOwmfufkdfhiLzhXIsG3bZYcsWhUaUVLltLW31qIDdililjMvsQNcZT-3yyu-gCJzAkzaZ1jlfs6myvIry6PV4iOBs_Sk7mgIdp-r33lQY_RXU0P-3mLP36O8" />
                    </div>
                    <div className="snap-center shrink-0 w-full h-full">
                        <img alt="Beau looking out window" className="w-full h-full object-cover"
                            src="https://lh3.googleusercontent.com/aida-public/AB6AXuAtUG8Lx3OAHUuExJwzxFn0yTrjoIdOkNwwpcQw2Iu4bgUjYSfLuPl_BaefygrHFJLE63AHpBJ-q0vtaHY5_UyoB_xPippbHF60t2Obpq7ldgHzzMGpR5e-eCiH5wT9mtCqVJytifvFkdAw_w8G2mco82kvaBKqpJj8etRD_8Khh2-GXVAeBNmQWhkEynviXmAEE0ZgdJkBXo97t7bY80tMOf9jdSyRYvIdy4R8OninPPxnAuBkjNcaccm7tPiDt5QaZwVK1Kgcpr4" />
                    </div>
                </div>
                {/* <!-- Navigation Arrows --> */}
                <button
                    className="absolute left-4 top-1/2 -translate-y-1/2 bg-surface/80 backdrop-blur p-3 rounded-full shadow-lg opacity-0 group-hover:opacity-100 transition-opacity z-10"
                    onClick={() => document.getElementById('hero-carousel')?.scrollBy({left: -600, behavior: 'smooth'})}>
                    <span className="material-symbols-outlined text-primary" data-icon="chevron_left">chevron_left</span>
                </button>
                <button
                    className="absolute right-4 top-1/2 -translate-y-1/2 bg-surface/80 backdrop-blur p-3 rounded-full shadow-lg opacity-0 group-hover:opacity-100 transition-opacity z-10"
                    onClick={() => document.getElementById('hero-carousel')?.scrollBy({left: 600, behavior: 'smooth'})}>
                    <span className="material-symbols-outlined text-primary" data-icon="chevron_right">chevron_right</span>
                </button>
                {/* <!-- Dot Indicators --> */}
                <div className="absolute bottom-6 left-1/2 -translate-x-1/2 flex gap-2 z-10">
                    <div className="w-2 h-2 rounded-full bg-primary"></div>
                    <div className="w-2 h-2 rounded-full bg-primary/30"></div>
                    <div className="w-2 h-2 rounded-full bg-primary/30"></div>
                    <div className="w-2 h-2 rounded-full bg-primary/30"></div>
                </div>
            </div>
  )
}

export default ImageCarousel
import React from 'react'

const FeaturedProducts = () => {
  return (
     <section className="px-6 md:px-12 py-32 max-w-screen-2xl mx-auto">
            <div className="text-center max-w-3xl mx-auto mb-20">
                <h2 className="text-4xl md:text-5xl font-extrabold tracking-tight mb-6">The Essentials Gallery</h2>
                <p className="text-on-surface-variant text-lg">Curated products that combine functional excellence with
                    aesthetic beauty. Because they deserve the best.</p>
            </div>
            <div className="grid grid-cols-1 md:grid-cols-3 gap-12">
                {/** Product Card 1*/} 
                <div className="group">
                    <div className="aspect-square rounded-lg bg-surface-container-low overflow-hidden mb-6 relative">
                        <img alt="Leather collar"
                            className="w-full h-full object-cover group-hover:scale-105 transition-transform duration-700"
                            data-alt="High-end tan leather dog collar with gold-finish metal buckle resting on a textured light grey stone surface"
                            src="https://lh3.googleusercontent.com/aida-public/AB6AXuCpzo58MJIqFeJVvOb_4UD8D253UpemJlEq5SbJyqOKRRcNbFo3rjNySE19za6vvYUMe4EmY3eDE3yRJVlAwEMwYP4rR5ERfYsxpTmTgL4lhMWnUDgUXrBW5vqFaamPSoWKgTSiFMOOBI81ZEvF8ncylDCM1FPy-EbeE0qqvK2SvDMYCrRo0GNhFPvA4zM-229vmV3QmB3SaLid7_Mc-Iokd2guACZxT5kCX5_DjUklVFTyAcwu234BnX5JM2COh3iCfryGIOVL9fk" />
                        <button
                            className="absolute bottom-4 right-4 w-12 h-12 bg-primary text-on-primary rounded-full flex items-center justify-center shadow-lg opacity-0 group-hover:opacity-100 translate-y-4 group-hover:translate-y-0 transition-all">
                            <span className="material-symbols-outlined"
                                data-icon="add_shopping_cart">add_shopping_cart</span>
                        </button>
                    </div>
                    <div className="flex justify-between items-start">
                        <div>
                            <h4 className="font-bold text-lg mb-1">Artisan Leather Collar</h4>
                            <p className="text-sm text-on-surface-variant">Natural Tan • Hand-stitched</p>
                        </div>
                        <p className="font-bold text-primary">$85.00</p>
                    </div>
                </div>
                {/** Product Card 2*/} 
                <div className="group">
                    <div className="aspect-square rounded-lg bg-surface-container-low overflow-hidden mb-6 relative">
                        <img alt="Pet bowl"
                            className="w-full h-full object-cover group-hover:scale-105 transition-transform duration-700"
                            data-alt="Minimalist ceramic white pet bowl on a wooden stand against a clean off-white wall with soft shadows"
                            src="https://lh3.googleusercontent.com/aida-public/AB6AXuDlQZ6mmH07NSdyHeEzxocDcNabWuxi7KzD_Efnc5gojpSfCxipKxRWBrhILQ_phRIQ6V9k3hym2nHIJxKUfoaXuVu_g5xY6yoBnZjNYEtvdCkZrQyCvE6ZEi0hj5FTRETDyaZaijNSS5Rvcxcf7PwPtQBjC7Mj7uz5FtnHIPvvJ2A2k-HbvfHTgphZOWppU37ZV-IESs652K7uUOoZBgSUKuCAbAdCM2KIbqXDy0-NqjajT4mHAraa_MvRmGLyXHPuU4hooDBcxVU" />
                        <button
                            className="absolute bottom-4 right-4 w-12 h-12 bg-primary text-on-primary rounded-full flex items-center justify-center shadow-lg opacity-0 group-hover:opacity-100 translate-y-4 group-hover:translate-y-0 transition-all">
                            <span className="material-symbols-outlined"
                                data-icon="add_shopping_cart">add_shopping_cart</span>
                        </button>
                    </div>
                    <div className="flex justify-between items-start">
                        <div>
                            <h4 className="font-bold text-lg mb-1">Ceramic Dining Set</h4>
                            <p className="text-sm text-on-surface-variant">Stone White • Anti-slip base</p>
                        </div>
                        <p className="font-bold text-primary">$42.00</p>
                    </div>
                </div>
                {/*Product Card 3*/ }
                <div className="group">
                    <div className="aspect-square rounded-lg bg-surface-container-low overflow-hidden mb-6 relative">
                        <img alt="Organic food"
                            className="w-full h-full object-cover group-hover:scale-105 transition-transform duration-700"
                            data-alt="Eco-friendly package of premium grain-free dog food with clean typography and pet imagery on a natural wood surface"
                            src="https://lh3.googleusercontent.com/aida-public/AB6AXuCENOwh28aOAXPO8gQZXE1Cme_p6hWF36RW4cQM4Ss8xCcF4GxAVpAJOCJEkL_H--VLprCNCQKoaYtFJSFwl12SotNkkU_ku3JNEsV3ebeHO36Qy3ZUenPP3VKG14zyPkN6YhaYXUaAKxa8_X6WQ7mzuqvHCHCs1BW6Sg8hDZXRYuuIF7MbltJEDaHyVm6JbVUpg2wOLLuwyP9xE_7PCF8v16Czqg2v93ZxYU8L078Srl3bBqmhfvxpDcfHVUvW8YE_z0B7CqiowtE" />
                        <button
                            className="absolute bottom-4 right-4 w-12 h-12 bg-primary text-on-primary rounded-full flex items-center justify-center shadow-lg opacity-0 group-hover:opacity-100 translate-y-4 group-hover:translate-y-0 transition-all">
                            <span className="material-symbols-outlined"
                                data-icon="add_shopping_cart">add_shopping_cart</span>
                        </button>
                    </div>
                    <div className="flex justify-between items-start">
                        <div>
                            <h4 className="font-bold text-lg mb-1">Organic Harvest Blend</h4>
                            <p className="text-sm text-on-surface-variant">Chicken &amp; Sweet Potato</p>
                        </div>
                        <p className="font-bold text-primary">$29.00</p>
                    </div>
                </div>
            </div>
        </section>
  )
}

export default FeaturedProducts
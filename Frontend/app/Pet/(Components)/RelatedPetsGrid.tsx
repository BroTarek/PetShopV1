import React from 'react'

const RelatedPetsGrid = () => {
  return (
    <>
     <section>
            <div className="flex justify-between items-end mb-12">
                <div>
                    <h2 className="text-4xl font-extrabold tracking-tighter mb-2 font-headline">Similar Companions</h2>
                    <p className="text-on-surface-variant">Meet other curated souls waiting for their homes.</p>
                </div>
                <a className="text-primary font-bold underline underline-offset-8 decoration-secondary transition-all hover:decoration-4"
                    href="#">View All Pets</a>
            </div>
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
                {/* <!-- Related Card 1 --> */}
                <div
                    className="bg-surface-container-lowest rounded-lg overflow-hidden editorial-shadow hover:-translate-y-2 transition-transform duration-500 cursor-pointer">
                    <div className="h-80 overflow-hidden">
                        <img alt="Related Pet" className="w-full h-full object-cover"
                            src="https://lh3.googleusercontent.com/aida-public/AB6AXuDe_4QZ6gy24TFMYzhK8nzY_CQMoN4A14lf-yJqXYjCvuvIJzCeO7N57XQYmZ4S2pUJNHhdCAdSI7fvie3dF5VDdbMvD4tBcOFKWR0L8xzC2oc6kbgAGLKhiXsRcDnDryGKyEXEqw0llUxbHhuB0EkcMen81X2ZYjMzu75UHf1_L8k8k4r8W43WgFf3nVR1RVBCoOWODrDOXoKtjvijE435e4nRzz8OPB2kRARIH-7zy2PNhJAWLO_-XlExx7kTod-yhD5GCzewS3U" />
                    </div>
                    <div className="p-8">
                        <div className="flex justify-between items-center mb-2">
                            <h4 className="text-2xl font-bold font-headline">Oliver</h4>
                            <span className="text-xs font-bold text-on-surface-variant uppercase tracking-widest">3
                                Years</span>
                        </div>
                        <p className="text-on-surface-variant text-sm mb-6">A lively Beagle mix with a passion for
                            exploration and adventure.</p>
                        <div className="flex gap-2">
                            <span
                                className="bg-secondary-container text-on-secondary-container text-[10px] px-3 py-1 rounded-full font-bold">Active</span>
                            <span
                                className="bg-secondary-container text-on-secondary-container text-[10px] px-3 py-1 rounded-full font-bold">Kid-Friendly</span>
                        </div>
                    </div>
                </div>
                {/* <!-- Related Card 2 --> */}
                <div
                    className="bg-surface-container-lowest rounded-lg overflow-hidden editorial-shadow hover:-translate-y-2 transition-transform duration-500 cursor-pointer">
                    <div className="h-80 overflow-hidden">
                        <img alt="Related Pet" className="w-full h-full object-cover"
                            src="https://lh3.googleusercontent.com/aida-public/AB6AXuDOB0Gi8wEq_HSrnnXm_YZiVTIq1gZnyqn3uSV7ifxhn78uqHuoq2RjeK-_ag5AkPC5osJ-X1jp3qPGmqumoeX_EytPCzV9loiOASMnmXRXtkzUy1DR9e4U0BJE2aooNgvNA93yQ6LynPkY-c1zg0uL8smAV-o-pOi-1PyMml97D-TCWvQ8uD19Pm-Yod9KSglevWBdKfMm6DOuM7kZz9JG0eYM7L_OhfDbAIfsn9BS6rCDLyh_SAG1LWIRbZOvSSp9QvYzSDG8u0s" />
                    </div>
                    <div className="p-8">
                        <div className="flex justify-between items-center mb-2">
                            <h4 className="text-2xl font-bold font-headline">Daisy</h4>
                            <span className="text-xs font-bold text-on-surface-variant uppercase tracking-widest">5
                                Months</span>
                        </div>
                        <p className="text-on-surface-variant text-sm mb-6">A gentle Golden Retriever pup who loves belly
                            rubs and quiet evenings.</p>
                        <div className="flex gap-2">
                            <span
                                className="bg-secondary-container text-on-secondary-container text-[10px] px-3 py-1 rounded-full font-bold">Gentle</span>
                            <span
                                className="bg-secondary-container text-on-secondary-container text-[10px] px-3 py-1 rounded-full font-bold">Training</span>
                        </div>
                    </div>
                </div>
                {/* <!-- Related Card 3 --> */}
                <div
                    className="bg-surface-container-lowest rounded-lg overflow-hidden editorial-shadow hover:-translate-y-2 transition-transform duration-500 cursor-pointer">
                    <div className="h-80 overflow-hidden">
                        <img alt="Related Pet" className="w-full h-full object-cover"
                            src="https://lh3.googleusercontent.com/aida-public/AB6AXuDU8nPp5dpQ1AuYDfD-Q0tv1Sr4mbHsML8ZBfAEI-9tT46pmRmCaZvh0kk47UZP1OE0hW5jz14sX9WncHa6Txy8WkZdl4kAuWHV0r2WL3Z0LjZc-A5xh2xTJyCLXX_Dmvqd6Da8zLPfRCenWmoa-5XIRbpKmm24a3M8fX980G8noqJX1AIwD6MQ-1yEHK1ViLVF06MrTIy9_2UTskswnE8GhNUhfg082-ixjPgfZ0bd98zRgFy0LrQvqPH4CX_fu14Q_4xtd2YRIq4" />
                    </div>
                    <div className="p-8">
                        <div className="flex justify-between items-center mb-2">
                            <h4 className="text-2xl font-bold font-headline">Pippin</h4>
                            <span className="text-xs font-bold text-on-surface-variant uppercase tracking-widest">1
                                Year</span>
                        </div>
                        <p className="text-on-surface-variant text-sm mb-6">A charismatic Boston Terrier with endless energy
                            and a big heart.</p>
                        <div className="flex gap-2">
                            <span
                                className="bg-secondary-container text-on-secondary-container text-[10px] px-3 py-1 rounded-full font-bold">Spunky</span>
                            <span
                                className="bg-secondary-container text-on-secondary-container text-[10px] px-3 py-1 rounded-full font-bold">Solo-Pet</span>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </>
  )
}

export default RelatedPetsGrid